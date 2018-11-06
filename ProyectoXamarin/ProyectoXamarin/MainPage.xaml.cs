using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace ProyectoXamarin
{
    public partial class MainPage : ContentPage
    {
        List<JuegosResult> juegosresult;
        List<PostsResult> postresult;

        public MainPage()
        {
            InitializeComponent();
            LogoPrincipal.Source = "http://juegosennas.apphb.com/Imagenes/juegosennas-logo-min.png";
        }


        public string BuscarImagen(string ruta)
        {
            string rutaFinal = "http://juegosennas.apphb.com" + ruta;
            return rutaFinal;
        }
      
        protected override void OnAppearing()
        {
            base.OnAppearing();

            
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient client = new RestClient();
                juegosresult = await client.Get<JuegosResult>("http://juegosennas.apphb.com/api/JuegosApi");
                postresult = await client.Get<PostsResult>("http://juegosennas.apphb.com/api/PostsApi"); //Url de la API

                foreach (var item in juegosresult) //Cargo el menu desplegable de categorias.
                {
                    Categorias.Items.Add(item.Descripcion);
                }               
                
            });       
        }

        private void Categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaElegida.Text = Categorias.Items[Categorias.SelectedIndex];
            var Juego = juegosresult.Find(x => x.Descripcion == CategoriaElegida.Text);
            var PostsJuegoElegido = postresult.Where(x => x.IdJuego == Juego.Id);
            if (PostsJuegoElegido != null)
            {
                foreach (var item in PostsJuegoElegido)
                {                                     
                    Label Titulo = new Label();                             //MUESTRO TITULO DEL POST
                    Titulo.Text = item.Titulo;
                    Titulo.HorizontalOptions = LayoutOptions.Center;  
                    Titulo.TextColor = Color.Black;
                    Titulo.FontAttributes = FontAttributes.Bold;
                    Titulo.FontSize = 25;
                    PantallaPrincipal.Children.Add(Titulo);
                    Image Imagen = new Image();
                    if (juegosresult != null)
                    {
                        foreach (var game in juegosresult)
                        {
                            if (item.IdJuego == game.Id)
                            {
                                Imagen.Source = BuscarImagen(game.Imagen);  //MUESTRO IMAGEN DEL POST
                                break;
                            }
                        }
                    }
                    PantallaPrincipal.Children.Add(Imagen);
                    Label Descripcion = new Label();
                    Descripcion.Text = item.Descripcion;            //MUESTRO DESCRIPCION DEL POST
                    Descripcion.FontSize = 15;
                    PantallaPrincipal.Children.Add(Descripcion);
                    foreach (var Comment in item.Comentarios)   // MUESTRO COMENTARIOS DEL POST
                    {
                        Label AutorComentario = new Label();
                        AutorComentario.Text = Comment.Autor;
                        AutorComentario.FontAttributes = FontAttributes.Bold;
                        PantallaPrincipal.Children.Add(AutorComentario);
                        Label Comentario = new Label();
                        Comentario.Text = Comment.Contenido;
                        PantallaPrincipal.Children.Add(Comentario);
                    }
                    
                }
            }
            else
            {
                DisplayAlert("Error" , "No se encontraron posts en la categoría seleccionada.", "OK");
            }

        }

        //private void Categorias_SelectedIndexChanged_1(object sender, EventArgs e)
        //{

        //}

        //private void Categorias_SelectedIndexChanged_2(object sender, EventArgs e)
        //{

        //}

        //private void Categorias_SelectedIndexChanged_3(object sender, EventArgs e)
        //{

        //}

        //private void Button_Pressed(object sender, EventArgs e)
        //{

        //}

    }
}
