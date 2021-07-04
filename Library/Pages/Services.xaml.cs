using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Library.Pages
{
    /// <summary>
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
        List<Книги> BookList = Classes.BaseClass.Base.Книги.ToList();

        public Services()
        {
            InitializeComponent();
            DG.ItemsSource = BookList;
        }
        int i = -1;
        int Index;
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Книги S = BookList[i];
                Uri U = new Uri(S.Обложка, UriKind.RelativeOrAbsolute);
                ME.Source = U;
                //   i++;
            }
        }
        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = BookList[i];
                TB.Text = S.Название;
                //  i++;
            }

        }

        private void TextBlockAuthor_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = BookList[i];
                TB.Text = S.Авторы.Автор;
                //  i++;
            }

        }

        private void Avail_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = BookList[i];
                TB.Text = Convert.ToString(S.Количество_магазин);
                //  i++;
            }
        }



        private void Price_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            TB.Text = Convert.ToInt32(S.Цена) + "руб.";
        }

        int sum = 0;
        int PriceSum = 0;
        int DiscountPrice = 0;

        private void BNew_Click(object sender, RoutedEventArgs e)
        {
            Button BNew = (Button)sender;
            int ind = Convert.ToInt32(BNew.Uid);
            Index = Convert.ToInt32(BNew.Uid);
            Книги S = BookList[Index];
            int price = S.Цена;
            sum += 1;
            PriceSum += price;
            Count.Text = "Количество выбранных книг: " + sum;
            Price.Text = "Цена покупки: " + PriceSum + " рублей";
            Discount.Text = "Скидка составила: " + price;
        }

        private void BNew_Initialized(object sender, EventArgs e)
        {
            Button BNew = (Button)sender;
            if (BNew != null)
            {
                BNew.Uid = Convert.ToString(i);
            }
        }

    }
}