﻿using Franks_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Franks_Pizza.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        // UserBase connection
        private IUserBase _userBase;
        // Navigation
        private IPageService _pageService;

        private string _malePressed;
        private string _femalePressed;

        public User New_user { get; set; }


        public string MalePressed
        {
            get { return _malePressed; }
            set { SetValue(ref _malePressed, value); }
        }
        public string FemalePressed
        {
            get { return _femalePressed; }
            set { SetValue(ref _femalePressed, value); }
        }


        public ICommand RegisterClickedCommand { get; private set; }
        public ICommand MaleClickedCommand { get; private set; }
        public ICommand FemaleClickedCommand { get; private set; }


        public RegisterPageViewModel(IUserBase userBase, IPageService pageService)
        {
            _userBase = userBase;
            _pageService = pageService;
            New_user = new User();

            RegisterClickedCommand = new Command(async () => await Register());
            MaleClickedCommand = new Command(Male);
            FemaleClickedCommand = new Command(Female);
            MaleClickedCommand.Execute(null);
        }

        private async Task Register()
        {
            if (New_user.Sex == "Male")
                New_user.AvatarSource = "male.png";
            else
                New_user.AvatarSource = "female.png";


            if (String.IsNullOrEmpty(New_user.FirstName) || String.IsNullOrEmpty(New_user.LastName) || String.IsNullOrEmpty(New_user.Login) || String.IsNullOrEmpty(New_user.Password) || String.IsNullOrEmpty(New_user.Email) || String.IsNullOrEmpty(New_user.Phone) || String.IsNullOrEmpty(New_user.Address))
            {
                await _pageService.DisplayAlert("ERROR", "Please input all information!", "OK");
                return;
            }


            var flag = await _userBase.SearchUser(New_user.Login);


            if (!flag)
            {
                await _userBase.AddUser(New_user);

                await _pageService.DisplayAlert("Registration", "Registred successful", "OK");

                await _pageService.PopAsync();
            }
            else
            {
                await _pageService.DisplayAlert("Registration", "This login is already used!", "OK");
                return;
            }
        }

        private void Male()
        {
            MalePressed = "False";
            FemalePressed = "True";
            New_user.Sex = "Male";
        }

        private void Female()
        {
            MalePressed = "True";
            FemalePressed = "False";
            New_user.Sex = "Female";
        }
    }
}