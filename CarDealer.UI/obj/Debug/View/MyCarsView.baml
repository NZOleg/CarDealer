   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      ?$clr-namespace:CarDealer.UI.ViewModelCarDealer.UI.ViewModel  5   	   "    CarDealer.UI.View.MyCarsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      :	viewModel$clr-namespace:CarDealer.UI.ViewModel     5   	     � 	Resources  5       �� DataType2  ,CarDealer.UI.ViewModel.SaleListItemViewModel   SaleListRowTemplate �� 
TargetType �� Property �� Value � ColumnDefinitions �� Path �� RelativeSource �� AncestorType  NaviItemContainerStyle  NaviItemTemplate	 �� 
TargetType
 �Name �� Triggers P� Property P� Value��%p  (��       5      *, +)&	       &	 �    &	     7   �� 6
   "  6   5      �� 5   
   " ��6,   .�5      ��  � �� 5      �� 5      .R�5      �  5      �� 5   "   $	��200 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   .+�5      �� $��0��6$   ��65   �� *FormattedDate+�� 5      $��1��6$   ��65   �� *Sale.Customer.Person.Username+�� 5      $��2��6$   ��64   �� **(Sale.IndividualCar.CarModel.Manufacturer+�� 5       $��3��6$   ��64   �� *#!Sale.IndividualCar.CarModel.Model+�� 5!      $��4��6$   ��64   �� *$"Sale.IndividualCar.ManufactureYear+�� 5"      $��5��6$   ��64   �� * Sale.Customer.Person.Telephone+�� 5#      ��6/   �� $ Content� �� *FindAncestor+" ��6�   5$      5&      5(      5)      �� 5*   
   " ��6/   .�5+      ��  � ��$
 Left=�64   �� 5,       � ��$ 2q�6'   5-      �� 5.   
   .R�5/      �� $
��Left=�51      $
��Left=�52      8��  $��16(�54      ��50      �� *OpenSaleDetailViewCommand+��52   4   �� ��55      �� 56      "	 ��6&   .R�57      � $

 grid��6   .+�58      �� #��z��6/   #��z��59   7   5:       5;      P� 5<       �@J�IsMouseOver . . �5=   "   ��  �@�Cursor$
 Hand��6;   �� 5>   "    � ��$
 Bold"�6?   5?      P� 5@       � �� . . �5A   "   ��  � ��$ Normal"�6?   5B      5D      5F      5G      5H      .��5I      � .+�5J   
   �� $��My Cars��6   .��5K      �� $
��Auto=�6   $
��Auto=�5L      .��5M      �� -   5         ��Name$ carList��5M      #��[ 5N      ��5M   0   �� *Cars+ �� Mode$ TwoWay=�5N      5P      5R      5S      5T      