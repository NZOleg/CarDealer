   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      %    CarDealer.UI.View.CarDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5        � 	Resources  5	         	boldStyle �� 
TargetType �� Property �� Value  FeaturesItemTemplate �� 
TargetType �Name �� Triggers P� Property P� Value��%�  &	        &	 J     �� 5
   
   " ��6"   .�5      ��  � ��$
 Bold"�6+   5      �� 5   
   .R�5      �� $��16(�6   ��6"   �� ��5      �� 5      " ��6&   .R�5      � $
 grid��6   .+�5      �� $
��Left=�6/   $	��Top=�5   7   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  � ��$
 Bold"�6?   5      5      5      5      5       .��5!      � 	 � RowDefinitions	 5"   
   �� 5#      $	��150 �6   �� 5$      $
��Auto �6   
 � ColumnDefinitions
 5'   
   �� 5(      $��2* �6   �� 5)      $��2* �6   �� 5*      $��1* �6   .+�5,   
   �� $��0��6   $��2��6    $��0��64   $
��auto��6A   $	��150��6N   $��5,5,5,4q�6{   ��6[   �� *Car.ImageUri+6{   �� 5-   
   $��0��6   $��1��6%     5.       �� BasedOn��%+   '��       7   �� 5/      8   " ��6=   50      .+�51      �� $��Colour:��6   �� 52   
   $��Current Mileage:��6   �� 53   
   $��Date Imported:��6   �� 54   
   $��Manufacture Year:��6   �� 55   
   $��Transmission:��6   �� 56   
   $��
Body Type:��6   �� 57   
   $��Manufacturer:��6   �� 58   
   $��Engine Size:��6   �� 59   
   $��Number Of Seats:��6   �� 5:   
   $��Status:��6   5;      �� 5=   
   $��2��6   $��0��6!   $
��Edit��6/   $��Center=�6f   $
��Left=�6�   $��75��6�   ��6>   �� *EditCarViewCommand+y�6�   �� *EditVisibility+�� 5>   
   $��2��6   $��0��6!   $	��Buy��6/   $��Center=�6`   $
��Left=�6{   $��75��6�   ��6=   �� *BuyCarCommand+y�6�   �� *BuyVisibility+�� 5?   
   $��1��6   $��1��6%   .+�5@   
   �� ��6   �� *
Car.Colour+�� 5A   
   ��6   �� *Car.CurrentMileage+�� 5C   
   ��6   �� *Car.DateImported+�� 5E   
   ��6   �� *Car.ManufactureYear+�� 5G   
   ��6   �� *Car.Transmission+�� 5I   
   ��6   �� *Car.BodyType+�� 5K   
   ��6   �� *Car.CarModel.Manufacturer+�� 5M   
   ��6   �� *Car.CarModel.EngineSize+�� 5O   
   ��6   �� *Car.CarModel.NumberOfSeats+�� 5Q   
   ��6   �� *
Car.Status+5R      �� 5S   
   $��1��6   $��2��6$   $
��Auto=�64   $
��Auto=�5T      .��5U      �� -   5         ��Name$ carList��5U      #��[ 5V      ��5U   -   �� *CarFeatures+ �� Mode$ TwoWay=�5V      5X      5Y      5Z      