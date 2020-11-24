using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blocnot
{




    public interface IMainWindow
    {
        string FilePath { get;}    
        string Content { get; set; }

        event EventHandler FileOpen;
        event EventHandler FileSave;
        event EventHandler ContentChange;

        void SetSymbolCount(int count); // todo создать на  форме 
    }



    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , IMainWindow
    {
        public string FilePath => tbFilePath.Text;


        string IMainWindow.Content 
        {
            get { return tbContent.DataContext.ToString(); } // todo возможно  криво примит
            set { tbContent.DataContext = value;  } 
        }
        
        public event EventHandler FileOpen;
        public event EventHandler FileSave;
        public event EventHandler ContentChange; 

        public MainWindow()
        {
            InitializeComponent();
            btOpen.Click += BtOpen_Click;
            btSave.Click += BtSave_Click;
            tbContent.TextChanged += TbContent_TextChanged;
        }

        private void TbContent_TextChanged(object sender, TextChangedEventArgs e)
        {
             if( ContentChange !=null)
            {
                ContentChange(this, EventArgs.Empty); // проброс событий
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if ( FileSave != null)
            {
                FileSave(this, EventArgs.Empty); // проброс событий
            }
        }

        private void BtOpen_Click(object sender, RoutedEventArgs e)
        {
           if ( FileOpen!=null)
            {
                FileOpen(this, EventArgs.Empty);
            }
        }


        public void SetSymbolCount(int count)
        {
            throw new NotImplementedException();
        }

        private void SlSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbContent.FontSize = slSize.Value;
        }
    }
}
