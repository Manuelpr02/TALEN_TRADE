using ProyectoFinal.Pages;
using ProyectoFinal.Models;
using ProyectoFinal.Database;
using System.Diagnostics;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Reactive.Concurrency;
namespace TestProject1
{
    // Clase para hacer los test del proyecto
    public class TestProyectoFinal
    {
        // Se crea el objeto de tipo random
        private static Random random = new Random();

        // Método para obtener valores de tipo string random
        private static string Stringr(int longitud)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz,.-_:;¨`^+çÇ!$%&/()=?'¿¡0123456789";
            return new string(Enumerable.Repeat(chars, longitud).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Método para obtener valores de tipo int random
        private static int Intr(int min, int max)
        {
            return random.Next(min, max);
        }

        // Tests para la unión de las pruebas unitarias, automáticas y manuales

        // Test para la clase Publicar
        [Fact]
        public void ValorClasePublicar()
        {
            // Se crea la instancia de la clase
            var publ = new Publicar(1, "Usuario", "Usuariopassw", "usuario@gmail.com", 2);

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual(3, publ.id);
            Assert.NotEqual("Usuario1", publ.Nomb);
            Assert.NotEqual("Usuariopassw1", publ.Pass);
            Assert.NotEqual("usuario@gmail.com1", publ.Correo);
            Assert.NotEqual(21, publ.IDCat);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, publ.id);
            Assert.Equal("Usuario", publ.Nomb);
            Assert.Equal("Usuariopassw", publ.Pass);
            Assert.Equal("usuario@gmail.com", publ.Correo);
            Assert.Equal(2, publ.IDCat);

        }

        // Test para la clase Mensaje
        [Fact]
        public void ValorMensaje()
        {
            // Se crea la instancia de la clase
            Mensaje mensaje = new Mensaje
            {
                emisor = "s",
                idcom = 1,
                idofer = 2,
                fech = DateTime.Now,
                mensaje = "HOLA",
                nombreprod = "Producto"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("a", mensaje.emisor);
            Assert.NotEqual("a", mensaje.mensaje);
            Assert.NotEqual("a", mensaje.nombreprod);
            Assert.NotEqual(3, mensaje.idofer);
            Assert.NotEqual(2, mensaje.idcom);
            Assert.NotEqual(DateTime.Now, mensaje.fech);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, mensaje.idcom);
            Assert.Equal(2, mensaje.idofer);
            Assert.Equal("s", mensaje.emisor);
            Assert.Equal("HOLA", mensaje.mensaje);
            Assert.Equal("Producto", mensaje.nombreprod);
        }

        // Test para la clase Usuario
        [Fact]
        public void ValorUsuario()
        {
            // Se crea la instancia de la clase
            Usuario user = new Usuario
            {
                idusario = 1,
                ciudad = "Córdoba",
                color = "Rojo",
                correo = "Correo",
                edad = "22",
                nombre = "Lucas",
                password = "password",
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("a", user.ciudad);
            Assert.NotEqual("a", user.color);
            Assert.NotEqual("a", user.correo);
            Assert.NotEqual("a", user.edad);
            Assert.NotEqual("a", user.password);
            Assert.NotEqual("a", user.nombre);
            Assert.NotEqual(2, user.idusario);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal("Córdoba", user.ciudad);
            Assert.Equal("Rojo", user.color);
            Assert.Equal("Correo", user.correo);
            Assert.Equal("22", user.edad);
            Assert.Equal("password", user.password);
            Assert.Equal("Lucas", user.nombre);
            Assert.Equal(1, user.idusario);
        }

        // Test para la clase Compras
        [Fact]
        public void ValorCompras()
        {
            // Se crea la instancia de la clase
            Compras compras = new Compras
            {
                idComprador = "1",
                idVendedor = "2",
                Idcompra = "1_2",
                Fecha = DateTime.Now,
                NombrePro = "Nombre"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("2", compras.idComprador);
            Assert.NotEqual("1", compras.idVendedor);
            Assert.NotEqual("2_1", compras.Idcompra);
            Assert.NotEqual(DateTime.Now, compras.Fecha);
            Assert.NotEqual("Nombre ", compras.NombrePro);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal("1", compras.idComprador);
            Assert.Equal("2", compras.idVendedor);
            Assert.Equal("1_2", compras.Idcompra);
            Assert.Equal("Nombre", compras.NombrePro);
        }

        // Test para la clase Producto
        [Fact]
        public void ValorProducto()
        {
            // Se crea la instancia de la clase
            Producto producto = new Producto
            {
                IdCategoria = 1,
                Idpr = 2,
                IdUsuario = 3,
                NombreProducto = "Producto",
                NombreUsuario = "Usuario",
                Descripcion = "Descripción",
                Direccion = "Dirección",
                Imagen = "Imagen",
                Precio = "Precio"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual(2, producto.IdCategoria);
            Assert.NotEqual(1, producto.Idpr);
            Assert.NotEqual(2, producto.IdUsuario);
            Assert.NotEqual("Producto ", producto.NombreProducto);
            Assert.NotEqual("Usuario ", producto.NombreUsuario);
            Assert.NotEqual("Descripcion", producto.Descripcion);
            Assert.NotEqual("Dirección ", producto.Direccion);
            Assert.NotEqual("Imagen ", producto.Imagen);
            Assert.NotEqual("Precio ", producto.Precio);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, producto.IdCategoria);
            Assert.Equal(2, producto.Idpr);
            Assert.Equal(3, producto.IdUsuario);
            Assert.Equal("Producto", producto.NombreProducto);
            Assert.Equal("Usuario", producto.NombreUsuario);
            Assert.Equal("Descripción", producto.Descripcion);
            Assert.Equal("Dirección", producto.Direccion);
            Assert.Equal("Imagen", producto.Imagen);
            Assert.Equal("Precio", producto.Precio);
        }

        // Test para la clase UsuarioMensaje
        [Fact]
        public void ValorUsuarioMensaje()
        {
            // Se crea la instancia de la clase
            UsuarioMensaje usermensg = new UsuarioMensaje
            {
                mensaje = new Mensaje
                {
                    emisor = "s",
                    idcom = 1,
                    idofer = 2,
                    fech = DateTime.Now,
                    mensaje = "HOLA",
                    nombreprod = "Producto"
                },
                usuario = new Usuario
                {
                    idusario = 1,
                    ciudad = "Córdoba",
                    color = "Rojo",
                    correo = "Correo",
                    edad = "22",
                    nombre = "Lucas",
                    password = "password",
                },
                notificacion = "!",
                colornoti = "rojo"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("a", usermensg.mensaje.emisor);
            Assert.NotEqual("a", usermensg.mensaje.mensaje);
            Assert.NotEqual("a", usermensg.mensaje.nombreprod);
            Assert.NotEqual(3, usermensg.mensaje.idofer);
            Assert.NotEqual(2, usermensg.mensaje.idcom);
            Assert.NotEqual(DateTime.Now, usermensg.mensaje.fech);
            Assert.NotEqual("a", usermensg.usuario.ciudad);
            Assert.NotEqual("a", usermensg.usuario.color);
            Assert.NotEqual("a", usermensg.usuario.correo);
            Assert.NotEqual("a", usermensg.usuario.edad);
            Assert.NotEqual("a", usermensg.usuario.password);
            Assert.NotEqual("a", usermensg.usuario.nombre);
            Assert.NotEqual(2, usermensg.usuario.idusario);
            Assert.NotEqual("¡", usermensg.notificacion);
            Assert.NotEqual("Verde", usermensg.colornoti);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, usermensg.mensaje.idcom);
            Assert.Equal(2, usermensg.mensaje.idofer);
            Assert.Equal("s", usermensg.mensaje.emisor);
            Assert.Equal("HOLA", usermensg.mensaje.mensaje);
            Assert.Equal("Producto", usermensg.mensaje.nombreprod);
            Assert.Equal("Córdoba", usermensg.usuario.ciudad);
            Assert.Equal("Rojo", usermensg.usuario.color);
            Assert.Equal("Correo", usermensg.usuario.correo);
            Assert.Equal("22", usermensg.usuario.edad);
            Assert.Equal("password", usermensg.usuario.password);
            Assert.Equal("Lucas", usermensg.usuario.nombre);
            Assert.Equal(1, usermensg.usuario.idusario);
            Assert.Equal("!", usermensg.notificacion);
            Assert.Equal("rojo", usermensg.colornoti);
        }

        //Tests para las pruebas de Integración

        // Test para la clase Usuario
        [Fact]
        public void PruebasUsuario()
        {
            // Se crea la instancia de la clase
            Usuario user = new Usuario
            {
                idusario = 1,
                ciudad = "Córdoba",
                color = "Rojo",
                correo = "Correo",
                edad = "22",
                nombre = "Lucas",
                password = "password",
            };
            LocalDB.NuevoUsuario(user.nombre, user.correo, user.password, user.ciudad, user.edad, user.color);
        }

        // Test para probar la subida de imagen
        [Fact]
        public void ValorClasePublicarSubirImagen()
        {
            // Se crea la instancia de la clase
            var publ = new Publicar(1, "Usuario", "Usuariopassw", "usuario@gmail.com", 2);

            //Se le pasa la url para que devuelva la dirección y se imprime
            var url = publ.SubirImagenAsync("http//:.......");

            Console.Write(url);

        }

        // Test para la clase Producto
        [Fact]
        public async void PruebasProducto()
        {
            // Se crea la instancia de la clase
            Producto producto = new Producto
            {
                IdCategoria = 1,
                Idpr = 2,
                IdUsuario = 3,
                NombreProducto = "Producto",
                NombreUsuario = "Usuario",
                Descripcion = "Descripción",
                Direccion = "Dirección",
                Imagen = "Imagen",
                Precio = "Precio"
            };

            // Se añade a la base de datos
            LocalDB.NuevoProducto(producto.Idpr, producto.NombreProducto, producto.IdCategoria, producto.NombreUsuario, producto.Descripcion, producto.Precio, producto.Direccion, producto.Imagen);

        }

        // Test para las pruebas Funcionales

        // Test para la clase Producto
        [Fact]
        public async void PruebasFuncionalesProducto()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            Producto producto = new Producto
            {
                IdCategoria = Intr(1, 10),
                Idpr = Intr(1, 10),
                IdUsuario = Intr(1, 10),
                NombreProducto = Stringr(10),
                NombreUsuario = Stringr(8),
                Descripcion = Stringr(20),
                Direccion = Stringr(15),
                Imagen = Stringr(10),
                Precio = Stringr(5)
            };

            // Se añade a la base de datos
            LocalDB.NuevoProducto(producto.Idpr, producto.NombreProducto, producto.IdCategoria, producto.NombreUsuario, producto.Descripcion, producto.Precio, producto.Direccion, producto.Imagen);

            var prod = LocalDB.GetProducto(producto.Idpr);

            // Se para de contar el tiempo
            tiemp.Stop();
        }


        // Test para la clase Productos
        [Fact]
        public async void PruebasFuncionalesProductos()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            var productos = LocalDB.GetAllProductos();

            // Se para de contar el tiempo
            tiemp.Stop();
        }

        // Test para la clase Usuario
        [Fact]
        public async void PruebasFuncionalesUsuario()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            Usuario user = new Usuario
            {
                idusario = Intr(1, 10),
                ciudad = Stringr(10),
                color = Stringr(10),
                correo = Stringr(10) + "@test.com",
                edad = Intr(18, 70).ToString(),
                nombre = Stringr(10),
                password = Stringr(10)
            };

            // Se añade a la base de datos
            LocalDB.NuevoUsuario(user.nombre, user.correo, user.password, user.ciudad, user.edad, user.color);

            var usuario = LocalDB.GetUsuario(user.idusario);

            // Se para de contar el tiempo 
            tiemp.Stop();
        }

        // Test para las pruebas de Capacidad

        // Test para la clase Producto
        [Fact]
        public async void PruebasCapacidadProducto()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            // Se crean 1000000 productos para medir el rendimiento
            for (int i = 0; i < 500000; i++)
            {
                Producto producto = new Producto
                {
                    IdCategoria = Intr(1, 10),
                    Idpr = i + 1,
                    IdUsuario = Intr(1, 10),
                    NombreProducto = Stringr(10),
                    NombreUsuario = Stringr(8),
                    Descripcion = Stringr(20),
                    Direccion = Stringr(15),
                    Imagen = Stringr(10),
                    Precio = Stringr(5)
                };

                // Se añade a la base de datos
                LocalDB.NuevoProducto(producto.Idpr, producto.NombreProducto, producto.IdCategoria, producto.NombreUsuario, producto.Descripcion, producto.Precio, producto.Direccion, producto.Imagen);

            }

            // Se para de contar el tiempo y se muestra
            tiemp.Stop();
            Console.WriteLine($"Tiempo de ejecución: {tiemp.Elapsed}");
        }

        // Test para la clase Usuario
        [Fact]
        public async void PruebasCapacidadUsuario()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            // Se crean 1000000 usuario para medir el rendimiento
            for (int i = 0; i < 500000; i++)
            {
                Usuario user = new Usuario
                {
                    idusario = i + 1,
                    ciudad = Stringr(10),
                    color = Stringr(10),
                    correo = Stringr(10) + "@test.com",
                    edad = Intr(18, 70).ToString(),
                    nombre = Stringr(10),
                    password = Stringr(10)
                };

                // Se añade a la base de datos
                LocalDB.NuevoUsuario(user.nombre, user.correo, user.password, user.ciudad, user.edad, user.color);
            }

            // Se para de contar el tiempo y se muestra
            tiemp.Stop();
            Console.WriteLine($"Tiempo de ejecución: {tiemp.Elapsed}");
        }

        // Test para la clase Mensaje
        [Fact]
        public async void PruebasCapacidadMensajes()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            // Se crean 1000000 mensajes para medir el rendimiento
            for (int i = 0; i < 500000; i++)
            {
                Mensaje mensaje = new Mensaje
                {
                    idofer = i + 1,
                    idcom = i + 1,
                    mensaje = Stringr(50),
                    emisor = Stringr(10),
                    nombreprod = Stringr(20),
                    fech = DateTime.Now
                };

            }

            // Se para de contar el tiempo y se muestra
            tiemp.Stop();
            Console.WriteLine($"Tiempo de ejecución: {tiemp.Elapsed}");
        }

        // Test para la clase Compras
        [Fact]
        public async void PruebasCapacidadCompras()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            // Se crean 1000000 compras para medir el rendimiento
            for (int i = 0; i < 500000; i++)
            {
                Compras compra = new Compras
                {
                    Idcompra = (i + 1).ToString(),
                    idComprador = (i + 1).ToString(),
                    idVendedor = (i + 1).ToString(),
                    NombrePro = Stringr(20),
                    Fecha = DateTime.Now
                };

            }

            // Se para de contar el tiempo y se muestra
            tiemp.Stop();
            Console.WriteLine($"Tiempo de ejecución: {tiemp.Elapsed}");
        }

        // Test para la clase UsuarioMensaje
        [Fact]
        public async void PruebasCapacidadUsuarioMensaje()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            // Se crean 1000000 usuariosmensaje para medir el rendimiento
            for (int i = 0; i < 500000; i++)
            {
                UsuarioMensaje usrmen = new UsuarioMensaje
                {
                    usuario = new Usuario
                    {
                        idusario = i + 1,
                        ciudad = Stringr(10),
                        color = Stringr(10),
                        correo = Stringr(10) + "@test.com",
                        edad = Intr(18, 70).ToString(),
                        nombre = Stringr(10),
                        password = Stringr(10)
                    },
                    mensaje = new Mensaje
                    {
                        idofer = i + 1,
                        idcom = i + 1,
                        mensaje = Stringr(50),
                        emisor = Stringr(10),
                        nombreprod = Stringr(20),
                        fech = DateTime.Now
                    },
                    notificacion = Stringr(20),
                    colornoti = Stringr(20)
                };
            }

            // Se para de contar el tiempo y se muestra
            tiemp.Stop();
            Console.WriteLine($"Tiempo de ejecución: {tiemp.Elapsed}");
        }

        // Test para las pruebas de Rendimiento

        // Test para la clase Producto
        [Fact]
        public void PruebasRendimientoProducto()
        {
            // Se crean 1000000 productos para medir el rendimiento
            for (int i = 0; i < 1000000; i++)
            {
                Producto producto = new Producto
                {
                    IdCategoria = Intr(1, 10),
                    Idpr = i + 1,
                    IdUsuario = Intr(1, 10),
                    NombreProducto = Stringr(10),
                    NombreUsuario = Stringr(8),
                    Descripcion = Stringr(20),
                    Direccion = Stringr(15),
                    Imagen = Stringr(10),
                    Precio = Stringr(5)
                };

                // Se añade a la base de datos
                LocalDB.NuevoProducto(producto.Idpr, producto.NombreProducto, producto.IdCategoria, producto.NombreUsuario, producto.Descripcion, producto.Precio, producto.Direccion, producto.Imagen);

            }
        }

        // Test para la clase Usuario
        [Fact]
        public async void PruebasRendimientoUsuario()
        {
            // Se crean 1000000 usuario para medir el rendimiento
            for (int i = 0; i < 1000000; i++)
            {
                Usuario user = new Usuario
                {
                    idusario = i + 1,
                    ciudad = Stringr(10),
                    color = Stringr(10),
                    correo = Stringr(10) + "@test.com",
                    edad = Intr(18, 70).ToString(),
                    nombre = Stringr(10),
                    password = Stringr(10)
                };

                // Se añade a la base de datos
                LocalDB.NuevoUsuario(user.nombre, user.correo, user.password, user.ciudad, user.edad, user.color);
            }
        }

        // Test para la clase Mensaje
        [Fact]
        public async void PruebasRendimientoMensajes()
        {
            // Se crean 1000000 mensajes para medir el rendimiento
            for (int i = 0; i < 1000000; i++)
            {
                Mensaje mensaje = new Mensaje
                {
                    idofer = i + 1,
                    idcom = i + 1,
                    mensaje = Stringr(50),
                    emisor = Stringr(10),
                    nombreprod = Stringr(20),
                    fech = DateTime.Now
                };

            }
        }

        // Test para la clase Compras
        [Fact]
        public async void PruebasRendimientoCompras()
        {
            // Se crean 1000000 compras para medir el rendimiento
            for (int i = 0; i < 1000000; i++)
            {
                Compras compra = new Compras
                {
                    Idcompra = (i + 1).ToString(),
                    idComprador = (i + 1).ToString(),
                    idVendedor = (i + 1).ToString(),
                    NombrePro = Stringr(20),
                    Fecha = DateTime.Now
                };

            }
        }

        // Test para la clase UsuarioMensaje
        [Fact]
        public async void PruebasRendimientoUsuarioMensaje()
        {
            // Se crean 1000000 usuariosmensaje para medir el rendimiento
            for (int i = 0; i < 1000000; i++)
            {
                UsuarioMensaje usrmen = new UsuarioMensaje
                {
                    usuario = new Usuario
                    {
                        idusario = i + 1,
                        ciudad = Stringr(10),
                        color = Stringr(10),
                        correo = Stringr(10) + "@test.com",
                        edad = Intr(18, 70).ToString(),
                        nombre = Stringr(10),
                        password = Stringr(10)
                    },
                    mensaje = new Mensaje
                    {
                        idofer = i + 1,
                        idcom = i + 1,
                        mensaje = Stringr(50),
                        emisor = Stringr(10),
                        nombreprod = Stringr(20),
                        fech = DateTime.Now
                    },
                    notificacion = Stringr(20),
                    colornoti = Stringr(20)
                };
            }
        }

        //Tests para las pruebas de Regresión

        // Test para la clase Usuario
        [Fact]
        public async void PruebasRegresionUsuario()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            // Se crea la instancia de la clase
            Usuario user = new Usuario
            {
                idusario = 1,
                ciudad = "Córdoba",
                color = "Rojo",
                correo = "Correo",
                edad = "22",
                nombre = "Lucas",
                password = "password",
            };

            // Se obtiene la id que imprime al modificar el método y se imprime
            var id = LocalDB.NuevoUsuario(user.nombre, user.correo, user.password, user.ciudad, user.edad, user.color);

            Console.WriteLine(id);

            // Se para de contar el tiempo
            tiemp.Stop();
        }

        // Test para la clase Producto
        [Fact]
        public async void PruebasRegresionProducto()
        {
            // Se instancia para contar el tiempo que tarda
            Stopwatch tiemp = Stopwatch.StartNew();

            Producto producto = new Producto
            {
                IdCategoria = Intr(1, 10),
                Idpr = Intr(1, 10),
                IdUsuario = Intr(1, 10),
                NombreProducto = Stringr(10),
                NombreUsuario = Stringr(8),
                Descripcion = Stringr(20),
                Direccion = Stringr(15),
                Imagen = Stringr(10),
                Precio = Stringr(5)
            };

            // Se obtiene la id que imprime al modificar el método y se imprime
            var id = LocalDB.NuevoProducto(producto.Idpr, producto.NombreProducto, producto.IdCategoria, producto.NombreUsuario, producto.Descripcion, producto.Precio, producto.Direccion, producto.Imagen);

            Console.WriteLine(id);

            // Se para de contar el tiempo
            tiemp.Stop();
        }

        // Tests para las pruebas de Seguridad

        // Test para la clase Publicar
        [Fact]
        public void SeguridadPublicar()
        {
            // Se crea la instancia de la clase
            var publ = new Publicar(int.Parse("1"), "Usuario", "Usuariopassw", "usuario@gmail.com", int.Parse("2"));

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual(3, publ.id);
            Assert.NotEqual("Usuario1", publ.Nomb);
            Assert.NotEqual("Usuariopassw1", publ.Pass);
            Assert.NotEqual("usuario@gmail.com1", publ.Correo);
            Assert.NotEqual(21, publ.IDCat);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, publ.id);
            Assert.Equal("Usuario", publ.Nomb);
            Assert.Equal("Usuariopassw", publ.Pass);
            Assert.Equal("usuario@gmail.com", publ.Correo);
            Assert.Equal(2, publ.IDCat);
        }

        // Test para la clase Mensaje
        [Fact]
        public void SeguridadMensaje()
        {
            // Se crea la instancia de la clase
            Mensaje mensaje = new Mensaje
            {
                emisor = "s",
                idcom = int.Parse("1"),
                idofer = int.Parse("2"),
                fech = DateTime.Now,
                mensaje = "HOLA",
                nombreprod = "Producto"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("a", mensaje.emisor);
            Assert.NotEqual("a", mensaje.mensaje);
            Assert.NotEqual("a", mensaje.nombreprod);
            Assert.NotEqual(3, mensaje.idofer);
            Assert.NotEqual(2, mensaje.idcom);
            Assert.NotEqual(DateTime.Now, mensaje.fech);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, mensaje.idcom);
            Assert.Equal(2, mensaje.idofer);
            Assert.Equal("s", mensaje.emisor);
            Assert.Equal("HOLA", mensaje.mensaje);
            Assert.Equal("Producto", mensaje.nombreprod);
        }

        // Test para la clase Usuario
        [Fact]
        public void SeguridadUsuario()
        {
            // Se crea la instancia de la clase
            Usuario user = new Usuario
            {
                idusario = int.Parse("1"),
                ciudad = "Córdoba",
                color = "Rojo",
                correo = "Correo",
                edad = 22.ToString(),
                nombre = "Lucas",
                password = "password",
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("a", user.ciudad);
            Assert.NotEqual("a", user.color);
            Assert.NotEqual("a", user.correo);
            Assert.NotEqual("a", user.edad);
            Assert.NotEqual("a", user.password);
            Assert.NotEqual("a", user.nombre);
            Assert.NotEqual(2, user.idusario);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal("Córdoba", user.ciudad);
            Assert.Equal("Rojo", user.color);
            Assert.Equal("Correo", user.correo);
            Assert.Equal("22", user.edad);
            Assert.Equal("password", user.password);
            Assert.Equal("Lucas", user.nombre);
            Assert.Equal(1, user.idusario);
        }

        // Test para la clase Compras
        [Fact]
        public void SeguridadCompras()
        {
            // Se crea la instancia de la clase
            Compras compras = new Compras
            {
                idComprador = 1.ToString(),
                idVendedor = 2.ToString(),
                Idcompra = "1_2",
                Fecha = DateTime.Now,
                NombrePro = "Nombre"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("2", compras.idComprador);
            Assert.NotEqual("1", compras.idVendedor);
            Assert.NotEqual("2_1", compras.Idcompra);
            Assert.NotEqual(DateTime.Now, compras.Fecha);
            Assert.NotEqual("Nombre ", compras.NombrePro);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal("1", compras.idComprador);
            Assert.Equal("2", compras.idVendedor);
            Assert.Equal("1_2", compras.Idcompra);
            Assert.Equal("Nombre", compras.NombrePro);
        }

        // Test para la clase Producto
        [Fact]
        public void SeguridadProducto()
        {
            // Se crea la instancia de la clase
            Producto producto = new Producto
            {
                IdCategoria = int.Parse("1"),
                Idpr = int.Parse("2"),
                IdUsuario = int.Parse("3"),
                NombreProducto = "Producto",
                NombreUsuario = "Usuario",
                Descripcion = "Descripción",
                Direccion = "Dirección",
                Imagen = "Imagen",
                Precio = "Precio"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual(2, producto.IdCategoria);
            Assert.NotEqual(1, producto.Idpr);
            Assert.NotEqual(2, producto.IdUsuario);
            Assert.NotEqual("Producto ", producto.NombreProducto);
            Assert.NotEqual("Usuario ", producto.NombreUsuario);
            Assert.NotEqual("Descripcion", producto.Descripcion);
            Assert.NotEqual("Dirección ", producto.Direccion);
            Assert.NotEqual("Imagen ", producto.Imagen);
            Assert.NotEqual("Precio ", producto.Precio);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, producto.IdCategoria);
            Assert.Equal(2, producto.Idpr);
            Assert.Equal(3, producto.IdUsuario);
            Assert.Equal("Producto", producto.NombreProducto);
            Assert.Equal("Usuario", producto.NombreUsuario);
            Assert.Equal("Descripción", producto.Descripcion);
            Assert.Equal("Dirección", producto.Direccion);
            Assert.Equal("Imagen", producto.Imagen);
            Assert.Equal("Precio", producto.Precio);
        }

        // Test para la clase UsuarioMensaje
        [Fact]
        public void SeguridadUsuarioMensaje()
        {
            // Se crea la instancia de la clase
            UsuarioMensaje usermensg = new UsuarioMensaje
            {
                mensaje = new Mensaje
                {
                    emisor = "s",
                    idcom = int.Parse("1"),
                    idofer = int.Parse("2"),
                    fech = DateTime.Now,
                    mensaje = "HOLA",
                    nombreprod = "Producto"
                },
                usuario = new Usuario
                {
                    idusario = int.Parse("1"),
                    ciudad = "Córdoba",
                    color = "Rojo",
                    correo = "Correo",
                    edad = 22.ToString(),
                    nombre = "Lucas",
                    password = "password",
                },
                notificacion = "!",
                colornoti = "rojo"
            };

            // Se verifica que no sean iguales los datos del objeto creado
            Assert.NotEqual("a", usermensg.mensaje.emisor);
            Assert.NotEqual("a", usermensg.mensaje.mensaje);
            Assert.NotEqual("a", usermensg.mensaje.nombreprod);
            Assert.NotEqual(3, usermensg.mensaje.idofer);
            Assert.NotEqual(2, usermensg.mensaje.idcom);
            Assert.NotEqual(DateTime.Now, usermensg.mensaje.fech);
            Assert.NotEqual("a", usermensg.usuario.ciudad);
            Assert.NotEqual("a", usermensg.usuario.color);
            Assert.NotEqual("a", usermensg.usuario.correo);
            Assert.NotEqual("a", usermensg.usuario.edad);
            Assert.NotEqual("a", usermensg.usuario.password);
            Assert.NotEqual("a", usermensg.usuario.nombre);
            Assert.NotEqual(2, usermensg.usuario.idusario);
            Assert.NotEqual("¡", usermensg.notificacion);
            Assert.NotEqual("Verde", usermensg.colornoti);

            // Se verifica que  sean iguales los datos del objeto creado
            Assert.Equal(1, usermensg.mensaje.idcom);
            Assert.Equal(2, usermensg.mensaje.idofer);
            Assert.Equal("s", usermensg.mensaje.emisor);
            Assert.Equal("HOLA", usermensg.mensaje.mensaje);
            Assert.Equal("Producto", usermensg.mensaje.nombreprod);
            Assert.Equal("Córdoba", usermensg.usuario.ciudad);
            Assert.Equal("Rojo", usermensg.usuario.color);
            Assert.Equal("Correo", usermensg.usuario.correo);
            Assert.Equal("22", usermensg.usuario.edad);
            Assert.Equal("password", usermensg.usuario.password);
            Assert.Equal("Lucas", usermensg.usuario.nombre);
            Assert.Equal(1, usermensg.usuario.idusario);
            Assert.Equal("!", usermensg.notificacion);
            Assert.Equal("rojo", usermensg.colornoti);
        }
    }
}