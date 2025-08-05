using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TiendaMVC.Models;
using TiendaMVC.Servicios;

namespace TiendaMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AplicacionDbContext context;
        private readonly IWebHostEnvironment environment;

        // Constructor que inyecta el contexto de base de datos y el entorno web
        public ProductosController(AplicacionDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        // Muestra la lista de productos ordenados por Id descendente
        public IActionResult Index()
        {
            var productos = context.Productos.OrderByDescending(p => p.Id).ToList(); 
            return View(productos);
        }
        // Muestra el formulario para crear un nuevo producto
        public IActionResult Crear()
        {
            return View();
        }

        // Procesa la creación de un nuevo producto (POST)
        [HttpPost]
        public IActionResult Crear(ProductoDto productoDto)
        {
            // Validación: imagen obligatoria
            if ( productoDto.ProductoImagen == null)
            {
                ModelState.AddModelError("ProductoImagen", "El archivo de imagen es requerido");
            }

            if(!ModelState.IsValid)
            {
                return View(productoDto);
            }

            // Guardar la imagen en la carpeta wwwroot/ImagenesProductos
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(productoDto.ProductoImagen!.FileName);

            string imagenFullPath = environment.WebRootPath + "/ImagenesProductos/"+ newFileName;
            using (var stream = System.IO.File.Create(imagenFullPath))
            {
                productoDto.ProductoImagen.CopyTo(stream);  
            }

            // Crear entidad Producto a partir del DTO
            Producto producto = new Producto()
            {
                Nombre = productoDto.Nombre,
                Marca = productoDto.Marca,
                Categoria = productoDto.Categoria,
                Precio = productoDto.Precio,
                Descripcion = productoDto.Descripcion,
                ProductoImagen = newFileName,
                Fecha = DateTime.Now,
            };


            //Guardar el producto en la base de datos
            context.Productos.Add(producto);
            context.SaveChanges();


            return RedirectToAction("Index", "Productos");
        }

        // Muestra el formulario de edición de un producto existente
        public IActionResult Editar(int id)
        {
            var producto = context.Productos.Find(id);

            if (producto == null)
            {
                return RedirectToAction("Index", "Productos");
                //return View("Error");
            }

            //Crear el producto nuevo
            var productodto = new ProductoDto()
            {
                Nombre = producto.Nombre,
                Marca = producto.Marca,
                Categoria = producto.Categoria,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion, 
            };

            ViewData["ProductoId"] = producto.Id;
            ViewData["ProductoImagen"] = producto.ProductoImagen;
            ViewData["Fecha"] = producto.Fecha.ToString("MM/dd/yyyy");
            return View(productodto);
        }

        // Procesa la actualización de un producto existente
        [HttpPost]
        public IActionResult Editar(int id, ProductoDto productoDto) 
        {
            var producto = context.Productos.Find(id);

            if (producto == null)
            {
                return RedirectToAction("Index", "Productos");
                //return View("Error");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProductoId"] = producto.Id;
                ViewData["ProductoImagen"] = producto.ProductoImagen;
                ViewData["Fecha"] = producto.Fecha.ToString("MM/dd/yyyy");
                return View(productoDto);   
            }

            string newFileName = producto.ProductoImagen;
            if (productoDto.ProductoImagen != null) 
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(productoDto.ProductoImagen.FileName);

                string imageFullPath = environment.WebRootPath +"/ImagenesProductos/"+ newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    productoDto.ProductoImagen.CopyTo(stream);
                }

                //borrar la imagen vieja
                string oldImageFullPath = environment.WebRootPath + "/ImagenesProductos/" + producto.ProductoImagen;
                System.IO.File.Delete(oldImageFullPath);

            }

            //Actualizar el producto en la base de datos

            producto.Nombre = productoDto.Nombre;
            producto.Marca = productoDto.Marca;
            producto.Categoria = productoDto.Categoria;
            producto.Precio = productoDto.Precio;
            producto.Descripcion = productoDto.Descripcion;
            producto.ProductoImagen = newFileName;

            context.SaveChanges();
            return RedirectToAction("Index", "Productos");

        }

        // Elimina un producto existente (y su imagen asociada)
        public IActionResult Eliminar(int id)
        {
            var producto = context.Productos.Find(id);

            if (producto == null)
            {
                return RedirectToAction("Index", "Productos");
                //return View("Error");
            }

            string ImageFullPath = environment.WebRootPath + "/ImagenesProductos/" + producto.ProductoImagen;
            System.IO.File.Delete(ImageFullPath);

            context.Productos.Remove(producto);
            context.SaveChanges();
            return RedirectToAction("Index", "Productos");

        }






    }
}
