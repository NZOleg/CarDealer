   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      ?$clr-namespace:CarDealer.UI.ViewModelCarDealer.UI.ViewModel  5	   	   #    CarDealer.UI.View.CarListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      0viewclr-namespace:CarDealer.UI.View     5      :	viewModel$clr-namespace:CarDealer.UI.ViewModel     5	   	     � 	Resources  5       �� DataType0   *CarDealer.UI.ViewModel.CarFiltersViewModel&    CarDealer.UI.View.CarFiltersView1   +CarDealer.UI.ViewModel.CarListItemViewModel   CarListRowTemplate �� 
TargetType �� Property �� Value � ColumnDefinitions �� Orientation �� Path �� RelativeSource	 �� AncestorType  NaviItemContainerStyle  NaviItemTemplate
 �� 
TargetType �Name �� Triggers P� Property P� Value��%�  (��       5      *, +)(�� 2     5      *, +)&	  S     &	 �    &	 l    7   �� 5   
   "  6   .R�5        5      �� 5   
   "  6   5      �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      .R�5      �  5      �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   �� 5   "   $	��150 �63   �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   .+�5       �� $��0��6$   ��65   �� *Car.CarModel.Manufacturer+�� 5!      $��1��6$   ��65   �� *Car.CarModel.Model+�� 5"      $��2��6$   ��64   �� *Car.ManufactureYear+�� 5#      $��3��6$   ��64   �� *Car.BodyType+�� 5$      $��4��6$   ��64   �� *Car.Transmission+�� 5%      $��5��6)   $ 
Horizontal=�69   .+�5&   "   �� ��6(   �� *Car.CurrentMileage+�� 5'   "   $��km��6(   5(      �� 5)      $��6��6)   $ 
Horizontal=�69   .+�5*   "   �� ��6(   �� *Car.CarModel.EngineSize+�� 5+   "   $��cc��6(   5,      �� 5-      $��7��6)   $ 
Horizontal=�69   .+�5/   "   �� $��$��6(   �� 50   "   ��6(   �� *Car.AskingPrice+51      �� 52      ��6/   �� $ Content� �� *FindAncestor+"	 ��6�   53      55      57      58      �� 59   
   " ��6/   .�5:      ��  � ��$
 Left=�64   �� 5;       � ��$ 2q�6'   5<      �� 5=   
   .R�5>      �� 8��  $
��Left=�6A   $
��Left=�6c   $��16(�5A      ��5>   ~   �� ��5?      �� *OpenCarDetailViewCommand+��5B      �� 5C      "
 ��6&   .R�5D      � $
 grid��6   .+�5E      �� $
��Left=�6/   $	��Top=�5F   7   5H       5I      P� 5J       �@J�IsMouseOver . . �5K   "   ��  �@�Cursor$
 Hand��6;   �� 5L   "    � ��$
 Bold"�6?   5M      P� 5N       � �� . . �5O   "   ��  � ��$ Normal"�6?   5P      5R      5T      5U      5V      .��5W      �  � RowDefinitions 5X   
   �� 5Y       5[   
   �� 5\      $	��300 �6   �� 5]      $��* �6   .+�5_   
   �� $��Car Filters��6   $��0 0 5 0q�6(   .��5`      �� $��0��6   ��5a      �� *CarFiltersViewModel+5b      �� 5c   
   $
��Cars��6   $��1��6"   .��5e      �� $
��Auto=�6   $
��Auto=�5f      .��5g      �  5h      �� 5i      $	��100 �6+   �� 5j      $	��100 �6+   �� 5k      $	��100 �6+   �� 5l      $	��150 �6+   �� 5m      $	��100 �6+   �� 5n      $	��100 �6+   �� 5o      $	��100 �6+   �� 5p      $	��100 �6+    5r      �� 5s      $
��auto �6(   �� 5t      .+�5v      �� $��Manufacturer��6   $��0��63   $��12(�6C   $��	ExtraBold"�6Q   �� 5w      $��Model��6   $��1��6,   $��12(�6<   $��	ExtraBold"�6J   �� 5x      $
��Year��6   $��2��6+   $��12(�6;   $��	ExtraBold"�6I   �� 5y      $��	Body Type��6   $��3��60   $��12(�6@   $��	ExtraBold"�6N   �� 5z      $��Transmission��6   $��4��63   $��12(�6C   $��	ExtraBold"�6Q   �� 5{      $��Mileage��6   $��5��6.   $��12(�6>   $��	ExtraBold"�6L   �� 5|      $��Engine��6   $��6��6-   $��12(�6=   $��	ExtraBold"�6K   �� 5}      $��Price��6   $��7��6,   $��12(�6<   $��	ExtraBold"�6J   �� 5      -   5         ��Name$ carList��5   E   $��1��6#   $��10��60   #��[ 5�      #��[ 5�      ��5   V   �� *Cars+ �� Mode$ TwoWay=�5�      5�      5�      5�      5�      5�      