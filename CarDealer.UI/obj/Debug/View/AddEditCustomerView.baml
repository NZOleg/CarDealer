   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      ;"clr-namespace:CarDealer.UI.HelpersCarDealer.UI.Helpers  5      +    %CarDealer.UI.View.AddEditCustomerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      5helper"clr-namespace:CarDealer.UI.Helpers     5      X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5	        � 	Resources  5      -   'CarDealer.UI.Helpers.IntToTextConverter   IntToTextConverter��%   &	          5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   � $��0 20 0 0q�6   $��1��6!   $��Center=�61   $��Center=�6L    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6     5(      �� 5)      $��1* �6#   �� 5*      $��1* �6#   .+�5,      �� $��0��6   $��0��6!   $��Licence Number:��61   $
��10 5q�6K   �� 5-      $��0��6   $��1��6$   $	��260��64   $
��10 5q�5.   C   ��5-   @   �� *Customer.LicenceNumber+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5.   C   �� 5/      $��1��6   $��0��6!   $
��Age:��61   $
��10 5q�6@   �� 50      $��1��6   $��1��6$   $	��260��64   $
��10 5q�51   r   ��50   @   �� *Customer.Age+$ TwoWay=�$ PropertyChanged=� �� 	Converter# [  51   r   �� 52      $��2��6   $��0��6!   $��License Expiry Date:��61   $
��10 5q�6P   (  "System.Windows.Controls.DatePicker  53      $��20(�6   $��2��6'   $��1��65   $	��260��6E   $
��10 5q�6�      SelectedDate 6Q   �� *Customer.LicenseExpiryDate+$ TwoWay=�$ PropertyChanged=�6�   �� 55      $��3��6   $��0��6!   $��Name:��61   $
��10 5q�6A   �� 56      $��3��6   $��1��6$   $	��260��64   $
��10 5q�57   C   ��56   @   �� *Customer.Person.Name+$ TwoWay=�$ PropertyChanged=�57   C   �� 58      $��4��6   $��0��6!   $��Address:��61   $
��10 5q�6D   �� 59      $��4��6   $��1��6$   $	��260��64   $
��10 5q�5:   C   ��59   @   �� *Customer.Person.Address+$ TwoWay=�$ PropertyChanged=�5:   C   �� 5;      $��5��6   $��0��6!   $��
Telephone:��61   $
��10 5q�6F   �� 5<      $��5��6   $��1��6$   $	��260��64   $
��10 5q�5=   C   ��5<   @   �� *Customer.Person.Telephone+$ TwoWay=�$ PropertyChanged=�5=   C   �� 5>      $��6��6   $��0��6!   $��	Username:��61   $
��10 5q�6E   �� 5?      $��6��6   $��1��6$   $	��260��64   $
��10 5q�5@   C   ��5?   @   �� *Customer.Person.Username+$ TwoWay=�$ PropertyChanged=�5@   C   �� 5A      $��7��6   $��0��6!   $��	Password:��61   $
��10 5q�6E   G� 5B      -   5         G�Name$ password��5B   D   $��7��6   $��1��6(   $	��260��68   $
��10 5q�6V   �� 5D      $��11��6   $��0��6'   $��2��67    �� Orientation$ 
Horizontal=�6K   .+�5E      �� $
��Save��6   $	��125��6(   $��10q�64   ��5F      �� *SaveCommand+��6/   �� 	 �� ElementName$	 password���� 5G      $��Delete��6   $	��125��6*   $��10q�67   ��5H      �� *DeleteCommand+y�61   �� *DeleteVisibility+5I      5J      5L      5M      