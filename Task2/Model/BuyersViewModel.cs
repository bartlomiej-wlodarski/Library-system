using Model.ViewModel;
using Service;
using System;
using System.Collections.Generic;
using Data;
using Data.API;

namespace Model
{
    public class BuyersViewModel : ViewModelBase, IBuyerViewModel
    {
        private BuyerService service;
        public BuyersViewModel(BuyerService service)
        {
            this.service = service;
        }
        public BuyersViewModel()
        {
            service = new BuyerService();
            AddBuyerCommand = new ActionBase(AddBuyer);
            UpdateBuyerCommand = new ActionBase(UpdateBuyer);
            DeleteBuyerCommand = new ActionBase(DeleteBuyer);
            RefreshBuyersCommand = new ActionBase(RefreshBuyers);
            ShowProductsCommand = new ActionBase(ShowProductsWindow);
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public ActionBase AddBuyerCommand { get; private set; }
        public ActionBase UpdateBuyerCommand { get; private set; }
        public ActionBase DeleteBuyerCommand { get; private set; }
        public ActionBase RefreshBuyersCommand { get; private set; }
        public ActionBase ShowProductsCommand { get; private set; }

        public void AddBuyer()
        {
            bool added = service.AddBuyer(Name, Surname, Phone);
            if (added)
            {
                text = "Buyer added";
            }
            else
            {
                text = "Cannot add Buyer";
            }
            MessageBoxShowDelegate(Text);
        }

        private IBuyer currentBuyer;
        public IBuyer CurrentBuyer
        {
            get => currentBuyer;
            set
            {
                currentBuyer = value;
                OnPropertyChanged("CurrentBuyer");
            }
        }
        public void UpdateBuyer()
        {
            bool updated = service.UpdateBuyer(ID, Name, Surname, Phone);
            if (updated)
            {
                text = "Buyer updated";
            }
            else
            {
                text = "Cannot update Buyer";
            }
            MessageBoxShowDelegate(Text);
        }
        public void DeleteBuyer()
        {
            bool deleted = service.DeleteBuyer(Phone);
            if (deleted)
            {
                text = "Buyer deleted";
            }
            else
            {
                text = "Cannot delete Buyer";
            }
            MessageBoxShowDelegate(Text);
        }

        public void RefreshBuyers()
        {
            Buyers = service.GetBuyers();
        }

        private IEnumerable<IBuyer> buyers;
        public IEnumerable<IBuyer> Buyers
        {
            get
            {
                return buyers;
            }
            set
            {
                buyers = value;
                OnPropertyChanged("Buyers");
            }
        }

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public Lazy<IWindow> ChildWindow { get; set; }

        private void ShowProductsWindow()
        {
            IWindow window = ChildWindow.Value;
            window.Show();
        }

        public Action<string> MessageBoxShowDelegate { get; set; }
    }
}