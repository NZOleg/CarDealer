   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      *    $CarDealer.UI.View.CustomerDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5        � 	Resources  5	         	boldStyle �� 
TargetType �� Property �� Value��%T   &	        �� 5
   
   " ��6"   .�5      ��  � ��$
 Bold"�6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��1��6%     5       �� BasedOn��%+   '��       7   �� 5      8   " ��6=   5      .+�5      �� $��LicenceNumber:��6   �� 5      $
��Age:��6   �� 5      $��License Expiry Date:��6   �� 5       $��Name:��6   �� 5!      $��Address:��6   �� 5"      $��
Telephone:��6   �� 5#      $��Username��6   5%      �� 5'   
   $��2��6   $��1��6!   $
��Edit��6/   $	��Top=�6k   $
��Left=�6�   $��75��6�   ��6>   �� *EditCustomerViewCommand+6�   �� 5(   
   $��1��6   $��1��6%   .+�5)      �� ��6   �� *Customer.LicenceNumber+�� 5+      ��6   �� *Customer.Age+�� 5-      ��6   �� *Customer.LicenseExpiryDate+�� 5/      ��6   �� *Customer.Person.Name+�� 51      ��6   �� *Customer.Person.Address+�� 53      ��6   �� *Customer.Person.Telephone+�� 55      ��6   �� *Customer.Person.Username+57      59      5:      