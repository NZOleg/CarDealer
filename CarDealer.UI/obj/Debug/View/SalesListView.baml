   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5   	   ?$clr-namespace:CarDealer.UI.ViewModelCarDealer.UI.ViewModel  5	   	   %    CarDealer.UI.View.SalesListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      0viewclr-namespace:CarDealer.UI.View     5   	   :	viewModel$clr-namespace:CarDealer.UI.ViewModel     5	   	     � 	Resources  5       �� DataType1   +CarDealer.UI.ViewModel.SaleFiltersViewModel'   !CarDealer.UI.View.SaleFiltersView2  ,CarDealer.UI.ViewModel.SaleListItemViewModel   SaleListRowTemplate �� 
TargetType �� Property �� Value � ColumnDefinitions �� Path �� RelativeSource �� AncestorType  NaviItemContainerStyle  NaviItemTemplate	 �� 
TargetType
 �Name �� Triggers P� Property P� Value��%�  (��       5      *, +)(�� 2     5      *, +)&	  S     &	 �    &	     7   �� 5   
   "  6   .R�5        5      �� 5   
   "  6   5      �� 5   
   " ��6,   .�5      ��  � �� 5      �� 5      .R�5      �  5      �� 5   "   $	��200 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   �� 5   "   $	��150 �63   .+�5      �� $��0��6$   ��65   �� *FormattedDate+�� 5       $��1��6$   ��65   �� *Sale.Customer.Person.Username+�� 5!      $��2��6$   ��64   �� **(Sale.IndividualCar.CarModel.Manufacturer+�� 5"      $��3��6$   ��64   �� *#!Sale.IndividualCar.CarModel.Model+�� 5#      $��4��6$   ��64   �� *$"Sale.IndividualCar.ManufactureYear+�� 5$      $��5��6$   ��64   �� * Sale.Customer.Person.Telephone+�� 5%      ��6/   �� $ Content� �� *FindAncestor+" ��6�   5&      5(      5*      5+      �� 5,   
   " ��6/   .�5-      ��  � ��$
 Left=�64   �� 5.       � ��$ 2q�6'   5/      �� 50   
   .R�51      �� $
��Left=�53      $
��Left=�54      8��  $��16(�56      ��52      �� *OpenSaleDetailViewCommand+��54   4   �� ��57      �� 58      "	 ��6&   .R�59      � $

 grid��6   .+�5:      �� #��z��6/   #��z��5;   7   5<       5=      P� 5>       �@J�IsMouseOver . . �5?   "   ��  �@�Cursor$
 Hand��6;   �� 5@   "    � ��$
 Bold"�6?   5A      P� 5B       � �� . . �5C   "   ��  � ��$ Normal"�6?   5D      5F      5H      5I      5J      .��5K      �  5L   
   �� 5M      $	��300 �6   �� 5N      $��* �6    � RowDefinitions 5P   
   �� 5Q      �� 5R      $
��auto �6   .+�5T   
   �� $��1��6   $
��Bold"�6    $��32(�62   $!��No Sales has been made yet!��6m   $��Center=�6�   $��Center=�6�   y�6@   �� *NoCarAlertVisibility+6�   �� 5U   
   $��Sale Filters��6   $��0 0 5 0q�6)   .��5V      �� $��0��6   ��5W      �� *SaleFiltersViewModel+5X      �� 5Y   
   $��1��6   $��Sales of Cars��6$   .��5Z      �� $
��Auto=�6   $
��Auto=�5[      .��5\      �  5]      �� 5^      $	��200 �6+   �� 5_      $	��150 �6+   �� 5`      $	��150 �6+   �� 5a      $	��150 �6+   �� 5b      $	��150 �6+   �� 5c      $	��150 �6+    5e      �� 5f      $
��auto �6(   �� 5g      .+�5i      �� $
��Date��6   $��0��6+   $��12(�6;   $��	ExtraBold"�6I   �� 5j      $��Username��6   $��1��6/   $��12(�6?   $��	ExtraBold"�6M   �� 5k      $��Manufacturer��6   $��2��63   $��12(�6C   $��	ExtraBold"�6Q   �� 5l      $��Model��6   $��3��6,   $��12(�6<   $��	ExtraBold"�6J   �� 5m      $
��Year��6   $��4��6+   $��12(�6;   $��	ExtraBold"�6I   �� 5n      $��Phone��6   $��5��6,   $��12(�6<   $��	ExtraBold"�6J   �� 5o      -   5         ��Name$ saleList��5o   E   $��1��6#   $��15��60   #��[ 5p      ��5o   W   �� *Sales+ �� Mode$ TwoWay=�5p      5q      5r      5t      �� 5u   
   $��1��6   $��1��6$   $��
Statistics��61   .��5v      �� .+�5w      ��  �� Orientation$ 
Horizontal=�6   .+�5x      �� $��20(�6   $��
Cars Sold:��6*   �� 5y      $��20(�6   ��6*   �� *	TotalCars+5z      �� 5{      $ 
Horizontal=�6   .+�5|      �� $��20(�6   $��Total Gross Sales ($):��6*   �� 5}      $��20(�6   ��6*   �� *TotalGrossSales+5~      5      5�      5�      5�      