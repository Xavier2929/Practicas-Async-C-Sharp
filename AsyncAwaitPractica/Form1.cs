using System;
using System.Net;

namespace AsyncAwaitPractica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            RunDownloadSync();

            watch.Stop();
            var elapseMs = watch.ElapsedMilliseconds;
            rtxtbxResults.Text += $"Total execution time: {elapseMs}";
        }

        private void RunDownloadSync()
        {
            List<string> website = PrepData();
            foreach (string site in website)
            {
                WebsiteDataModel results = DownloadWebsite(site);
                ReportWebsiteInfo(results);
            }
        }

        private List<string> PrepData()
        {
            List<string> output = new List<string>();
            rtxtbxResults.Text = "";

            output.Add("https://www.yahoo.com");
            output.Add("https://www.google.com");
            output.Add("https://www.cnn.com");
            output.Add("https://www.youtube.com");

            output.Add("https://www.github.com");
            return output;
        }

        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient cliente = new WebClient();
            output.WebsiteUrl = websiteURL;
            output.WebsiteData = cliente.DownloadString(websiteURL);

            return output;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            rtxtbxResults.Text += $" {data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long. {Environment.NewLine}";
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            //aqui es la unica excepcion de NO quitar el void, la razon es que este es un evento
            var watch = System.Diagnostics.Stopwatch.StartNew();
            await RunDownloadParallelAsync();

            watch.Stop();
            var elapseMs = watch.ElapsedMilliseconds;
            rtxtbxResults.Text += $"Total execution time: {elapseMs}";
        }

        private async Task RunDownloadAsync()
        {
            //! PRO TIP: Cuando tengas un metodo void y lo quieras hacer async, no lo dejes como void, hazlo Task, en caso si tienes de devolver algo seria Task<string> y devolveria un string

            List<string> website = PrepData();
            foreach (string site in website)
            {
                //lo que quiere decir este codigo es,  OK, corre esto en una tarea asincrona pero esperala porfa, ya que la vamos a usar
                WebsiteDataModel results = await Task.Run(() => DownloadWebsite(site));
                //Parece no muy logico hacer un metodo asincrono y que lo espere, pero lo que realmente significa es
                //aqui cualquier metodo que llame a este metodo lo llama y puede seguir con lo suyo, con esto minimo nuestra aplicacion puede ser responsiva aunque este corriendo este metodo asincrono
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            //! PRO TIP: Cuando tengas un metodo void y lo quieras hacer async, no lo dejes como void, hazlo Task, en caso si tienes de devolver algo seria Task<string> y devolveria un string

            List<string> website = PrepData();
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

            foreach (string site in website)
            {
                //ahora este este metodo dice lo siguiente:
                //Bueno tengo esta lista de tareas que debo de hacer pero, todavia no se termina, ponlo en esta lista porfavor, los cuales se van a ejecutar al mismo tiempo
                tasks.Add(Task.Run(() => DownloadWebsiteAsync(site)));
            }
            var results = await Task.WhenAll(tasks);
            //lo que esta linea dice, okay voy a crear esta variable que va a ser igual cuando un conjunto de tareas todas esten terminadas, y van a hacer las tareas de mi lista "tasks"
            foreach (var item in results)
            {
                ReportWebsiteInfo(item);
            }
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient cliente = new WebClient();
            output.WebsiteUrl = websiteURL;
            output.WebsiteData = await cliente.DownloadStringTaskAsync(websiteURL);
            //lo unico que acambia aqui es que hicimos asincrono este metodo tambien en el await cliente...

            return output;
        }
    }
}