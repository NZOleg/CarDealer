   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   G CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarDealer.UICarDealer.UI 5   	   5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View 5   	   ?$clr-namespace:CarDealer.UI.ViewModelCarDealer.UI.ViewModel 5	   	      CarDealer.UI.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ,localclr-namespace:CarDealer.UI     5   	   0viewclr-namespace:CarDealer.UI.View     5   	   :	viewModel$clr-namespace:CarDealer.UI.ViewModel     5	   	     � Title$  	CarDealer��5   	   $	��700��6   $
��1000��6(    � WindowStartupLocation$ CenterScreen=�5   	   $��20(�5   	    � 	Resources 5       �� DataType+  %CarDealer.UI.ViewModel.LoginViewModel!  CarDealer.UI.View.LoginView- 'CarDealer.UI.ViewModel.CarListViewModel#  CarDealer.UI.View.CarListView* $CarDealer.UI.ViewModel.MenuViewModel   CarDealer.UI.View.MenuView0 *CarDealer.UI.ViewModel.AddEditCarViewModel&   CarDealer.UI.View.AddEditCarView/	 )CarDealer.UI.ViewModel.CarDetailViewModel%
  CarDealer.UI.View.CarDetailView4 .CarDealer.UI.ViewModel.CustomerDetailViewModel*  $CarDealer.UI.View.CustomerDetailView0 *CarDealer.UI.ViewModel.SaleDetailViewModel&   CarDealer.UI.View.SaleDetailView2 ,CarDealer.UI.ViewModel.CustomerListViewModel(  "CarDealer.UI.View.CustomerListView5 /CarDealer.UI.ViewModel.AddEditCustomerViewModel+  %CarDealer.UI.View.AddEditCustomerView5 /CarDealer.UI.ViewModel.AddEditEmployeeViewModel+  %CarDealer.UI.View.AddEditEmployeeView. (CarDealer.UI.ViewModel.CheckoutViewModel$  CarDealer.UI.View.CheckoutView. (CarDealer.UI.ViewModel.SaleListViewModel%  CarDealer.UI.View.SalesListView2 ,CarDealer.UI.ViewModel.EmployeeListViewModel(  "CarDealer.UI.View.EmployeeListView4 .CarDealer.UI.ViewModel.EmployeeDetailViewModel*  $CarDealer.UI.View.EmployeeDetailView, &CarDealer.UI.ViewModel.MyCarsViewModel"  CarDealer.UI.View.MyCarsView��%e  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� �     5      *, +)(�� ,    5!      *, +)(�� ^    5$      *, +)(�� �    5'      *, +)(�� �    5*      *, +)(�� �    5-      *, +)(�� &    50      *, +)(�� X    53      *, +)(�� �    56      *, +)(�� �    59      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      �� 5   
   "  6   .R�5        5       �� 5!   
   "  6   .R�5"        5#      �� 5$   
   "  6   .R�5%        5&      �� 5'   
   "  6   .R�5(        5)      �� 5*   
   "  6   .R�5+        5,      �� 5-   
   "  6   .R�5.        5/      �� 50   
   "  6   .R�51        52      �� 53   
   "  6   .R�54        55      �� 56   
   "  6   .R�57        58      �� 59   
   "  6   .R�5:        5;      5<      .��5=      �  � RowDefinitions 5>   
   �� 5?      $
��Auto �6   �� 5@       � ColumnDefinitions 5D   
   �� 5E      $��1* �6   .+�5G   
   �� $��0��6   $��2��6&   ��5H      �� *LoginViewModel+�� 5I   
   $��1��6   ��5J      �� *CurrentView+�� 5K   
   $��0��6   ��5L      �� *MenuViewModel+5M      5O      