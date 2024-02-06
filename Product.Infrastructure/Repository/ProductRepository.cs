//Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Product.Core.Entities;
using Product.Core.Interface;
using Product.Core.Sharing;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;




        public ProductRepository(ApplicationDbContext context, IFileProvider fileProvider, IMapper mapper) : base(context)
        {
            _context = context;
            _fileProvider = fileProvider;
            _mapper = mapper;

        }


     

        public async Task<bool> AddAsync(CreateProductDto dto)
        {

            if (dto.Image is not null)
            {
                var root = "/images/product/";
                var prodcutname = $"{Guid.NewGuid()}" + dto.Image.FileName;
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                var src = root + prodcutname;
                var pic_info = _fileProvider.GetFileInfo(src);
                var root_path = pic_info.PhysicalPath;
                using (var file_streem = new FileStream(root_path, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(file_streem);

                }
                // Create New Product
                var res = _mapper.Map<Products>(dto);
                res.ProductPicture = src;
                await _context.Products.AddAsync(res);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        //update
        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var currentProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (currentProduct is not null)
            {

                var src = "";
                if (dto.Image is not null)
                {
                    var root = "/images/product/";
                    var productName = $"{Guid.NewGuid()}" + dto.Image.FileName;
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }

                    src = root + productName;
                    var picInfo = _fileProvider.GetFileInfo(src);
                    var rootPath = picInfo.PhysicalPath;
                    using (var fileStream = new FileStream(rootPath, FileMode.Create))
                    {
                        await dto.Image.CopyToAsync(fileStream);
                    }
                }
                //remove old picture
                if (!string.IsNullOrEmpty(currentProduct.ProductPicture))
                {
                    //delete old picture
                    var picInfo = _fileProvider.GetFileInfo(currentProduct.ProductPicture);
                    var rootPath = picInfo.PhysicalPath;
                    System.IO.File.Delete(rootPath);
                }

                //update product
                var res = _mapper.Map<Products>(dto);
                res.ProductPicture = src;
                res.Id = id;
                _context.Products.Update(res);
                await _context.SaveChangesAsync();


                return true;

            }
            return false;
        }

        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        //delete 
        public async Task<bool> DeleteAsync(int id)
        {
            var currentproduct = await _context.Products.FindAsync(id);
            if (!string.IsNullOrEmpty(currentproduct.ProductPicture))
            {
                //delete old pic
                var pic_info = _fileProvider.GetFileInfo(currentproduct.ProductPicture);
                var root_path = pic_info.PhysicalPath;
                System.IO.File.Delete($"{root_path}");

                // Delete Database
                _context.Products.Remove(currentproduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        async Task<ReturnProductDto> IProductRepository.GetAllAsync(ProductParams productParams)
        {
            var result_ = new ReturnProductDto();
            var query = await _context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
            //var query = await _context.Products
            //    .Include(x => x.Category)
            //    .AsNoTracking()
            //    .ToListAsync();

            //search by name
            if (!string.IsNullOrEmpty(productParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(productParams.Search)).ToList();

            //filtring by categoryId
            if (productParams.Categoryid.HasValue)
                query = query.Where(x => x.CategoryId == productParams.Categoryid.Value).ToList();

            //sorting
            if (!string.IsNullOrEmpty(productParams.Sorting))
            {
                query = productParams.Sorting switch
                {
                    "PriceAsc" => query.OrderBy(x => x.Price).ToList(),
                    "PriceDesc" => query.OrderByDescending(x => x.Price).ToList(),
                    _ => query.OrderBy(x => x.Name).ToList(),
                };
            }
            result_.TotalItems = query.Count;
            //paging          
            query = query.Skip((productParams.Pagesize) * (productParams.PageNumber - 1)).Take(productParams.Pagesize).ToList();

            result_.ProductDtos = _mapper.Map<List<ProductDto>>(query);
            return result_;
        }
    }
}
