   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      ?$clr-namespace:CarDealer.UI.ViewModelCarDealer.UI.ViewModel  5	   	   (    "CarDealer.UI.View.CustomerListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      :	viewModel$clr-namespace:CarDealer.UI.ViewModel     5	   	     � 	Resources  5       �� DataType6  0CarDealer.UI.ViewModel.CustomerListItemViewModel   NaviItemContainerStyle �� 
TargetType �� Property �� Value  CustomerListRowTemplate � ColumnDefinitions �� Path �� RelativeSource �� AncestorType  NaviItemTemplate	 �� 
TargetType
 �Name �� Triggers P� Property P� Value��%�  (��       5      *, +)&	       &	 �     &	 �    7  �� 6
   "  6   5      �� 5   
   " ��6/   .�5      ��  � ��$
 Left=�64   �� 5       � ��$ 2q�6'   5      �� 5   
   " ��60   .�5      ��  � �� 5      �� 5      .R�5      �  5      �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5    "   $	��200 �63   .+�5"      �� $��0��6$   ��65   �� *Customer.Person.Username+�� 5#      $��1��6$   ��65   �� *Customer.Person.Name+�� 5$      $��2��6$   ��64   �� *Customer.Age+�� 5%      $��3��6$   ��64   �� *Customer.Person.Telephone+�� 5&      $��4��6$   ��64   �� *Customer.LicenceNumber+�� 5'      ��6/   �� $ Content� �� *FindAncestor+" ��6�   5(      5*      5,      5-      �� 5/   
   .R�50      �� $
��Left=�52      $
��Left=�53      8��  $��16(�55      ��51      �� *OpenCustomerDetailViewCommand+��53   4   �� ��56      �� 57      "	 ��6&   .R�58      � $

 grid��6   .+�59      �� #��z��6/   #��z��5:   7   5;       5<      P� 5=       �@J�IsMouseOver . . �5>   "   ��  �@�Cursor$
 Hand��6;   �� 5?   "    � ��$
 Bold"�6?   5@      P� 5A       � �� . . �5B   "   ��  � ��$ Normal"�6?   5C      5E      5G      5H      5I      .��5J      � .+�5K   
   �� $��	Customers��6   .��5L      �� $
��Auto=�6   $
��Auto=�5M      .��5N      �� -   5         ��Name$ carList��5N   ;   $
��Left=�6   #��[  5O      #��[ 5P      ��5N   L   �� *	Customers+ �� Mode$ TwoWay=�5P      5R      5T      5U      5V      