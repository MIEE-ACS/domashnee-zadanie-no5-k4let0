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

namespace hometask5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class Shoes
    {
        int art;
        int size;
        int price;
        public int Art
        {
            set
            {
                if (value >= 100000 && value <= 999999) art = value;
            }
            get
            {
                return art;
            }
        }
        public int Size
        {
            set
            {
                if (value >= 16 && value <= 50) size = value;
            }
            get
            {
                return size;
            }
        }
        public int Price
        {
            set
            {
                if (value > 0) price = value;
            }
            get
            {
                return price;
            }
        }
        public override string ToString()
        {
            return $"арт {art} размер {size} цена {price}";
        }
        public Shoes(int a, int s, int p)
        {
            if (a >= 100000 && a <= 999999 && s >= 16 && s <= 50 && p > 0)
            {
                art = a;
                size = s;
                price = p;
            }
            else throw new Exception("Wrong data");
        }
    }
    public partial class MainWindow : Window
    {
        List<Shoes> shoes = new List<Shoes>
        {
            new Shoes(152761,40,4500),
            new Shoes(653149,32,7399),
            new Shoes(831050,42,6000),
            new Shoes(321689,25,10000),
            new Shoes(442751,36,5240),
        };
        public void UpdateShoesList()
        {
            lbShoes.Items.Clear();
            foreach(var shoe in shoes)
            {
                lbShoes.Items.Add(shoe);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            UpdateShoesList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isCorrect = true;
                foreach(var shoe in shoes)
                {
                    if (shoe.Art == int.Parse(tbArt.Text)) isCorrect = false;
                }
                if (isCorrect)
                {
                    Shoes boot = new Shoes(int.Parse(tbArt.Text), int.Parse(tbSize.Text), int.Parse(tbPrice.Text));
                    shoes.Add(boot);
                    UpdateShoesList();
                }
                else MessageBox.Show("Данный артикул занят", "Ошибка", MessageBoxButton.OK);
            }
            catch(Exception)
            {
                MessageBox.Show("Неверные значения", "Ошибка данных", MessageBoxButton.OK);
            }
        }

        private void BtnFindArt_Click(object sender, RoutedEventArgs e)
        {
            int art;
            if (int.TryParse(tbArtToFind.Text, out art) && art >= 100000 && art <= 999999)
            {
                lbShoes.Items.Clear();
                foreach (var shoe in shoes)
                {
                    if (shoe.Art == art) lbShoes.Items.Add(shoe);
                }
            }
            else MessageBox.Show("Некорректный артикул", "Ошибка", MessageBoxButton.OK);
        }

        private void BtnFindSize_Click(object sender, RoutedEventArgs e)
        {
            int size;
            if (int.TryParse(tbSizeToFind.Text, out size) && size >=16 && size <= 50)
            {
                lbShoes.Items.Clear();
                foreach (var shoe in shoes)
                {
                    if (shoe.Size == size) lbShoes.Items.Add(shoe);
                }
            }
            else MessageBox.Show("Некорректный размер", "Ошибка", MessageBoxButton.OK);
        }

        private void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            UpdateShoesList();
        }
    }
}
