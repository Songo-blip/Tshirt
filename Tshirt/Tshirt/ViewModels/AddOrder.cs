using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using SQLite;
using System.IO;
using Tshirt.Model;
using System.Linq;


namespace Tshirt.ViewModels
{
   public class AddOrder : INotifyPropertyChanged
    
    {
        public AddOrder()
        {
            SubmitOrderCommand = new Command(async()=> await SubmitOrder());
        }

        string name = string.Empty;
        string surname = string.Empty;
        string gender = string.Empty;
        string tshirtcolour = string.Empty;
        string dateoforder = string.Empty;
        string shippingaddress = string.Empty;
      

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "order.db");

        public event PropertyChangedEventHandler PropertyChanged;

        void onPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        } 

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                onPropertyChanged();
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                onPropertyChanged();
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                onPropertyChanged();
            }
        }

        public string DateOfOrder
        {
            get { return dateoforder; }
            set
            {
                dateoforder = value;
                onPropertyChanged();
            }
        }

        public string TShirtColour
        {
            get { return tshirtcolour; }
            set
            {
                tshirtcolour = value;
                onPropertyChanged();
            }
        }

        public string ShippingAddress
        {
            get { return shippingaddress; }
            set
            {
                shippingaddress = value;
                onPropertyChanged();
            }
        }


        public Command SubmitOrderCommand { get; }

        async Task SubmitOrder()
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<TshirtOrder>();
            var maxPK = db.Table<TshirtOrder>().OrderByDescending(c => c.Id).FirstOrDefault();

            TshirtOrder order = new TshirtOrder();
            db.Insert(order);
            await Application.Current.MainPage.DisplayAlert(order.Name, "Submit", "Ok");
        }
   }
}
