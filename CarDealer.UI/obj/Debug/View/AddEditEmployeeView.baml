   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      +    %CarDealer.UI.View.AddEditEmployeeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   � $��0 20 0 0q�6   $��1��6!   $��Center=�61   $��Center=�6L     5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6     5"      �� 5#      $��1* �6#   �� 5$      $��1* �6#   .+�5&      �� $��0��6   $��0��6!   $��Office Address:��61   $
��10 5q�6K   �� 5'      $��0��6   $��1��6$   $	��260��64   $
��10 5q�5(   C   ��5'   @   �� *Employee.OfficeAddress+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5(   C   �� 5)      $��1��6   $��0��6!   $��Phone Extension Number:��61   $
��10 5q�6S   �� 5*      $��1��6   $��1��6$   $	��260��64   $
��10 5q�5+   C   ��5*   @   �� *Employee.PhoneExtensionNumber+$ TwoWay=�$ PropertyChanged=�5+   C   �� 5,      $��2��6   $��0��6!   $��Role:��61   $
��10 5q�6A   �� 5-      $��2��6   $��1��6$   $	��260��64   $
��10 5q�5.   C   ��5-   @   �� *Employee.Role+$ TwoWay=�$ PropertyChanged=�5.   C   �� 5/      $��3��6   $��0��6!   $��Name:��61   $
��10 5q�6A   �� 50      $��3��6   $��1��6$   $	��260��64   $
��10 5q�51   C   ��50   @   �� *Employee.Person.Name+$ TwoWay=�$ PropertyChanged=�51   C   �� 52      $��4��6   $��0��6!   $��Address:��61   $
��10 5q�6D   �� 53      $��4��6   $��1��6$   $	��260��64   $
��10 5q�54   C   ��53   @   �� *Employee.Person.Address+$ TwoWay=�$ PropertyChanged=�54   C   �� 55      $��5��6   $��0��6!   $��
Telephone:��61   $
��10 5q�6F   �� 56      $��5��6   $��1��6$   $	��260��64   $
��10 5q�57   C   ��56   @   �� *Employee.Person.Telephone+$ TwoWay=�$ PropertyChanged=�57   C   �� 58      $��6��6   $��0��6!   $��	Username:��61   $
��10 5q�6E   �� 59      $��6��6   $��1��6$   $	��260��64   $
��10 5q�5:   C   ��59   @   �� *Employee.Person.Username+$ TwoWay=�$ PropertyChanged=�5:   C   �� 5;      $��7��6   $��0��6!   $��	Password:��61   $
��10 5q�6E   G� 5<      -   5         G�Name$ password��5<   D   $��7��6   $��1��6(   $	��260��68   $
��10 5q�6V   �� 5>      $��11��6   $��0��6'   $��2��67    �� Orientation$ 
Horizontal=�6K   .+�5?      �� $
��Save��6   $	��125��6(   $��10q�64   ��5@      �� *SaveCommand+��6/   ��  �� ElementName$ password���� 5A      $��Delete��6   $	��125��6*   $��10q�67   ��5B      �� *DeleteCommand+y�61   �� *DeleteVisibility+5C      5D      5F      5G      