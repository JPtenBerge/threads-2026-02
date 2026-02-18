using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	{
		var syncContext = SynchronizationContext.Current!;

		var t = new Thread(() =>
		{
			syncContext.Post(new SendOrPostCallback(state => { lblTekst.Content = "werkt ook!"; }), null);

			// lblTekst.Dispatcher.Invoke(() => lblTekst.Content = "werkt!");
		});
		t.Start();
		Thread.Sleep(2000);
		// Interlocked.
	}

	private void ButtonWorker_OnClick(object sender, RoutedEventArgs e)
	{
		var worker = new BackgroundWorker();

		worker.RunWorkerCompleted += (o, args) => lblVoortgang.Content = "Klaar!";
		worker.ProgressChanged += (o, args) => lblVoortgang.Content = $"Nu op {args.ProgressPercentage}%";
		worker.DoWork += (o, args) =>
		{
			worker.ReportProgress(10);
			Thread.Sleep(1000);
			worker.ReportProgress(40);
			Thread.Sleep(500);
			worker.ReportProgress(30);
			Thread.Sleep(2000);
			worker.ReportProgress(70);
			Thread.Sleep(1000);
			worker.ReportProgress(90);
			Thread.Sleep(1000);
			worker.ReportProgress(100);
			args.Result = 42;
		};
		worker.WorkerReportsProgress = true;
		worker.RunWorkerAsync();
		
		// Bla().Result
		// Bla().GetAwaiter().GetResult();
		// Bla().ContinueWith(result =>
		// {
		// 	result
		// })
	}

	private async Task<int> Bla()
	{
		return 4;
	}

}