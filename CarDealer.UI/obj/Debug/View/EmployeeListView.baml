   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      ?$clr-namespace:CarDealer.UI.ViewModelCarDealer.UI.ViewModel  5      (    "CarDealer.UI.View.EmployeeListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      :	viewModel$clr-namespace:CarDealer.UI.ViewModel     5        � 	Resources  5
       �� DataType6  0CarDealer.UI.ViewModel.EmployeeListItemViewModel   EmployeeListRowTemplate �� 
TargetType �� Property �� Value � ColumnDefinitions �� Path �� RelativeSource �� AncestorType  NaviItemContainerStyle  NaviItemTemplate	 �� 
TargetType
 �Name �� Triggers P� Property P� Value��%F  (��       5      *, +)&	       &	 }    &	 �    7   �� 6
   "  6   5      �� 5   
   " ��60   .�5      ��  � �� 5      �� 5      .R�5      �  5      �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   �� 5   "   $	��200 �63   .+�5      �� $��0��6$   ��65   �� *Employee.Person.Username+�� 5      $��1��6$   ��65   �� *Employee.Person.Name+�� 5      $��2��6$   ��64   �� *Employee.PhoneExtensionNumber+�� 5      $��3��6$   ��64   �� *Employee.Person.Telephone+�� 5       $��4��6$   ��64   �� *Employee.OfficeAddress+�� 5!      $��5��6$   ��64   �� *Employee.Role+�� 5"      ��6/   �� $ Content� �� *FindAncestor+" ��6�   5#      5%      5'      5(      �� 5)   
   " ��6/   .�5*      ��  � ��$
 Left=�64   �� 5+       � ��$ 2q�6'   5,      �� 5-   
   .R�5.      �� $
��Left=�50      $
��Left=�51      8��  $��16(�53      ��5/      �� *OpenEmployeeDetailViewCommand+��51   4   �� ��54      �� 55      "	 ��6&   .R�56      � $

 grid��6   .+�57      �� #��z��6/   #��z��58   7   59       5:      P� 5;       �@J�IsMouseOver . . �5<   "   ��  �@�Cursor$
 Hand��6;   �� 5=   "    � ��$
 Bold"�6?   5>      P� 5?       � �� . . �5@   "   ��  � ��$ Normal"�6?   5A      5C      5E      5F      5G      .��5H      � .+�5I   
   �� $��	Employees��6   .��5J      �� $
��Auto=�6   $
��Auto=�5K      .��5L      �� -   5         ��Name$ carList��5L      #��[ 5N      #��[ 5O      ��5L   0   �� *	Employees+ �� Mode$ TwoWay=�5O      5Q      5S      5T      5U      