using Pizza_Данилова.Models;
using System;
using System.Collections.Generic;
using System.IO; // Добавлено для работы File.Exists
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pizza_Данилова.Layouts
{
    public partial class Main : Page
    {
        // Переменные, которые не были объявлены
        public List<Dish> dish = new List<Dish>();
        public MainWindow win;

        public Main()
        {
            InitializeComponent();
        }

        public Main(MainWindow mainWin)
        {
            InitializeComponent();
            win = mainWin;
            // Здесь в будущем вы будете заполнять список dish
            // Например: dish = GetDishes();
            CreatePizza();
        }

        public void CreatePizza()
        {
            for (int i = 0; i < dish.Count; i++)
            {
                var bc = new BrushConverter();
                Grid global = new Grid();
                global.Height = 100;
                global.Background = (Brush)bc.ConvertFrom("#FFECECEC");
                if (i > 0) global.Margin = new Thickness(0, 10, 0, 0);

                Image logo = new Image();
                if (File.Exists(win.localPath + @"\image\dish\" + dish[i].img + ".png"))
                {
                    logo.Source = new BitmapImage(new Uri(win.localPath + @"\image\dish\" + dish[i].img + ".png"));
                }
                else
                {
                    logo.Source = new BitmapImage(new Uri(win.localPath + @"\image\logo.png"));
                }
                logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                logo.Height = 50;
                logo.Margin = new Thickness(10, 0, 0, 0);
                logo.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                logo.Width = 50;
                global.Children.Add(logo);

                Label name = new Label();
                name.Content = dish[i].name;
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                name.Margin = new Thickness(65, 0, 0, 0);
                name.FontWeight = FontWeights.Bold;
                global.Children.Add(name);

                Label description = new Label();
                description.Content = dish[i].description;
                description.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                description.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                description.Margin = new Thickness(65, 20, 0, 0);
                global.Children.Add(description);

                if (dish[i].ingredients.Count != 0)
                {
                    Label ingredient = new Label();
                    string str_ingredient = "";
                    for (int j = 0; j < dish[i].ingredients.Count; j++)
                    {
                        str_ingredient += dish[i].ingredients[j].name;
                        if (j != dish[i].ingredients.Count - 1)
                        {
                            str_ingredient += ", ";
                        }
                    }
                    ingredient.Content = "Состав: " + str_ingredient;
                    ingredient.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ingredient.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ingredient.Margin = new Thickness(65, 40, 0, 0);
                    global.Children.Add(ingredient);
                }

                Label price = new Label();
                price.Content = "Цена: " + dish[i].sizes[0].price + " р.";
                price.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                price.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                price.Margin = new Thickness(65, 0, 0, 10);
                global.Children.Add(price);

                Label wes = new Label();
                wes.Content = "Вес: " + dish[i].sizes[0].wes + " г.";
                wes.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                wes.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                wes.Margin = new Thickness(200, 0, 0, 10);
                global.Children.Add(wes);

                Button button1 = new Button();
                Button button2 = new Button();
                Button button3 = new Button();
                Button minus = new Button();
                Button plus = new Button();
                CheckBox order = new CheckBox();
                TextBox count = new TextBox(); // ДОБАВЛЕНО: создание TextBox

                button1.Content = dish[i].sizes[0].size + " см";
                button1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button1.Margin = new Thickness(0, 10, 110, 0);
                button1.Width = 45;
                button1.Height = 20;
                button1.Background = Brushes.White;
                button1.Foreground = (Brush)bc.ConvertFrom("#FFD33333");
                button1.Tag = i;
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dish[i].sizes[0].price + " р.";
                    wes.Content = "Вес: " + dish[i].sizes[0].wes + " г.";
                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFD33333");
                    button2.Background = (Brush)bc.ConvertFrom("#FFD33333");
                    button2.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#FFD33333");
                    button3.Foreground = Brushes.White;

                    dish[i].activeSize = 0;
                    count.Text = dish[i].sizes[0].countOrder.ToString();
                    order.IsChecked = dish[i].sizes[0].orders;
                };
                global.Children.Add(button1);

                button2.Content = dish[i].sizes[1].size + " см";
                button2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button2.Margin = new Thickness(0, 10, 60, 0);
                button2.Width = 45;
                button2.Height = 20;
                button2.Background = Brushes.White;
                button2.Foreground = (Brush)bc.ConvertFrom("#FFD33333");
                button2.Tag = i;
                button2.Click += delegate
                {
                    price.Content = "Цена: " + dish[i].sizes[1].price + " р.";
                    wes.Content = "Вес: " + dish[i].sizes[1].wes + " г.";
                    button1.Background = (Brush)bc.ConvertFrom("#FFD33333");
                    button1.Foreground = Brushes.White;
                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFD33333");
                    button3.Background = (Brush)bc.ConvertFrom("#FFD33333");
                    button3.Foreground = Brushes.White;

                    dish[i].activeSize = 1;
                    count.Text = dish[i].sizes[1].countOrder.ToString();
                    order.IsChecked = dish[i].sizes[1].orders;
                };
                global.Children.Add(button2);

                button3.Content = dish[i].sizes[2].size + " см";
                button3.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button3.Margin = new Thickness(0, 10, 10, 0);
                button3.Width = 45;
                button3.Height = 20;
                button3.Background = Brushes.White;
                button3.Foreground = (Brush)bc.ConvertFrom("#FFD33333");
                button3.Tag = i;
                button3.Click += delegate
                {
                    price.Content = "Цена: " + dish[i].sizes[2].price + " р.";
                    wes.Content = "Вес: " + dish[i].sizes[2].wes + " г.";
                    button1.Background = (Brush)bc.ConvertFrom("#FFD33333");
                    button1.Foreground = Brushes.White;
                    button2.Background = (Brush)bc.ConvertFrom("#FFD33333");
                    button2.Foreground = Brushes.White;
                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFD33333");

                    dish[i].activeSize = 2;
                    count.Text = dish[i].sizes[2].countOrder.ToString();
                    order.IsChecked = dish[i].sizes[2].orders;
                };
                global.Children.Add(button3);

                minus.Content = "-";
                minus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                minus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                minus.Margin = new Thickness(0, 0, 120, 10);
                minus.Width = 15;
                minus.Height = 15;
                minus.Tag = i;
                minus.Click += delegate
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) > 0)
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString();
                            int id = int.Parse(minus.Tag.ToString());
                            dish[id].sizes[dish[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(minus);

                count.Text = "0";
                count.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                count.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                count.Margin = new Thickness(0, 0, 30, 10);
                count.TextWrapping = TextWrapping.Wrap;
                count.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                count.Width = 80;
                count.Height = 15;
                count.Tag = i;
                global.Children.Add(count);

                plus.Content = "+";
                plus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                plus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                plus.Margin = new Thickness(0, 0, 10, 10);
                plus.Width = 15;
                plus.Height = 15;
                plus.Tag = i;
                plus.Click += delegate
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) < 15)
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString();
                            int id = int.Parse(plus.Tag.ToString());
                            dish[id].sizes[dish[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(plus);

                order.Content = "Выбрать";
                order.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                order.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                order.Margin = new Thickness(0, 0, 128, 12);
                order.Tag = i;
                order.Click += delegate
                {
                    int id = int.Parse(order.Tag.ToString());
                    dish[id].sizes[dish[id].activeSize].orders = (bool)order.IsChecked;
                };
                global.Children.Add(order);

                parent.Children.Add(global);
            }
        }
    }
}