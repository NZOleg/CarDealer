   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      +clr-namespace:CarDealer.UICarDealer.UI  5      ;"clr-namespace:CarDealer.UI.HelpersCarDealer.UI.Helpers  5      &     CarDealer.UI.View.AddEditCarView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      (cclr-namespace:CarDealer.UI     5      X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5      /helper"clr-namespace:CarDealer.UI.Helpers  5        � 	Resources  5      -   'CarDealer.UI.Helpers.IntToTextConverter   IntToTextConverter  FeaturesTemplate �� Orientation d� 	IsChecked �� Triggers P� Property P� Value �� Property �� Value��%=  &	        &	        5   
   6$   �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      ��  6   �� *	IsChecked+�� 5      ��6   �� *CarFeature.Feature+5       5      P� 5       �@J�IsMouseOver . . �5      ��  �@�Cursor$
 Hand��6/   5      5       5!      .��5#      �  � RowDefinitions 5$   
   �� 5%      $��* �6   �� 5&      $
��Auto �6   	 � ColumnDefinitions	 5)   
   �� 5*      $��2* �6   �� 5+      $��2* �6   �� 5,      $
��1.5* �6   .+�5.   
   � $��0��6   $��0��6   5/      � 50   
   $��0 20 0 0q�6   $��0��6!   $��Center=�61   $��Center=�6L    51      �� 52      $
��Auto �6    �� 53      $
��Auto �6    �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    �� 5:      $
��Auto �6    �� 5;      $
��Auto �6    �� 5<      $
��Auto �6    �� 5=      $
��Auto �6    	 5?      �� 5@      $��1* �6#   �� 5A      $��1* �6#   .+�5C      �� $��0��6   $��0��6!   $��Manufacturer:��61   $
��10 5q�6I   �� 5D      $��0��6   $��1��6$   $	��160��64   $
��10 5q�5E   C   ��5D   @   �� *Car.CarModel.Manufacturer+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5E   C   �� 5F      $��1��6   $��0��6!   $��Model:��61   $
��10 5q�6B   �� 5G      $��1��6   $��1��6$   $	��160��64   $
��10 5q�5H   C   ��5G   @   �� *Car.CarModel.Model+$
 TwoWay=�$ PropertyChanged=�5H   C   �� 5I      $��2��6   $��0��6!   $��Engine Size (cc):��61   $
��10 5q�6M   �� 5J      $��2��6   $��1��6$   $	��160��64   $
��10 5q�6@   .��6N   .��5K      ��  �� Path$ Car.CarModel.EngineSize�6   $ PropertyChanged=�5L      $
 TwoWay=�64    �� TargetNullValue$  ��6B    �� 	Converter# [  6U    �� ValidationRules 5M      "  CarDealer.UI.ValidationRules  5N         Type$ 
engineSize��6,   5P      5Q      �� 5R      $��3��6   $��0��6!   $��Manufacture Year:��61   $
��10 5q�6M   �� 5S      $��3��6   $��1��6$   $	��160��64   $
��10 5q�6A   .��6O   .��5T      �� $ Car.ManufactureYear�6   $ PropertyChanged=�5U      $
 TwoWay=�64   $  ��6B   # [  6U    5V        5W      $
 year��6,   5Y      5Z      �� 5[      $��4��6   $��0��6!   $��Transmission:��61   $
��10 5q�6I   �� 5\      $��4��6   $��1��6$   $	��160��64   $
��10 5q�5]   C   ��5\   @   �� *Car.Transmission+$
 TwoWay=�$ PropertyChanged=�5]   C   �� 5^      $��5��6   $��0��6!   $��
Body Type:��61   $
��10 5q�6F   �� 5_      $��5��6   $��1��6$   $	��160��64   $
��10 5q�5`   C   ��5_   @   �� *Car.BodyType+$
 TwoWay=�$ PropertyChanged=�5`   C   5b      � 5c   
   $��0 20 0 0q�6   $��1��6!   $��Center=�61   $��Center=�6L    5d      �� 5e      $
��Auto �6    �� 5f      $
��Auto �6    �� 5g      $
��Auto �6    �� 5h      $
��Auto �6    �� 5i      $
��Auto �6    �� 5j      $
��Auto �6    �� 5k      $��* �6    �� 5l      $
��Auto �6    	 5n      �� 5o      $��1* �6#   �� 5p      $��1* �6#   .+�5r      �� $��0��6   $��0��6!   $��Colour:��61   $
��10 5q�6C   �� 5s      $��0��6   $��1��6$   $	��160��64   $
��10 5q�5t   C   ��5s   @   �� *
Car.Colour+$
 TwoWay=�$ PropertyChanged=�5t   C   �� 5u      $��1��6   $��0��6!   $��Current Mileage:��61   $
��10 5q�6L   �� 5v      $��1��6   $��1��6$   $	��160��64   $
��10 5q�6@   .��6N   .��5w      �� $ Car.CurrentMileage�6   $ PropertyChanged=�5x      $
 TwoWay=�64   $  ��6B   # [  6U    5y        5z      $ currentMileage��6,   5|      5}      �� 5~      $��2��6   $��0��6!   $��Number Of Seats:��61   $
��10 5q�6L   �� 5      $��2��6   $��1��6%   $	��160��65   $
��10 5q�6B   .��6Q   .��5�      �� $  Car.CarModel.NumberOfSeats�6   $ PropertyChanged=�5�      $
 TwoWay=�64   $  ��6B   # [  6U    5�        5�      $ numberOfSeats��6,   5�      5�      �� 5�      $��3��6   $��0��6!   $��Date Imported:��61   $
��10 5q�6J   (  "System.Windows.Controls.DatePicker  5�      $��3��6   $��20(�6&   $��1��65   $	��160��6E   $
��10 5q�6�      SelectedDate 6Q   �� *Car.DateImported+$
 TwoWay=�$ PropertyChanged=�6�   �� 5�      $��4��6   $��0��6!   $��Asking Price:��61   $
��10 5q�6I   �� 5�      $��4��6   $��1��6$   $	��160��64   $
��10 5q�6@   .��6N   .��5�      �� $ Car.AskingPrice�6   $ PropertyChanged=�5�      $
 TwoWay=�64   $  ��6B   # [  6U    5�        5�      $ askingPrice��6,   5�      5�      �� 5�      $��5��6   $��0��6!   $��
Image URI:��61   $
��10 5q�6F   �� 5�      $��5��6   $��1��6$   $	��160��64   $
��10 5q�5�   C   ��5�   @   �� *Car.ImageUri+$
 TwoWay=�$ PropertyChanged=�5�   C   5�      �� 5�   
   $��1��6   $��0��6"   $��2��62   $ 
Horizontal=�6F   $��Center=�6_   .+�5�      �� $
��Save��6   $	��125��6$   $��10q�60   ��5�      �� *SaveCommand+�� 5�      $��Delete��6   $	��125��6&   $��10q�63   ��5�      �� *DeleteCommand+y�61   �� *DeleteVisibility+5�      � 5�   
   $��2��6   $��0 0 10 0q�6   .+�5�      �� $��Features��6   .��5�      �� $
��Auto=�6   $
��Auto=�5�      .��5�      �� -   5         ��Name$ carList��5�   #   #��[ 5�      ��5�   4   �� *CarFeatures+$
 TwoWay=�5�      5�      5�      5�      5�      5�      