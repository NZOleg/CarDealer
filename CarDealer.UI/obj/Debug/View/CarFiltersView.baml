   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      +clr-namespace:CarDealer.UICarDealer.UI  5	      ;"clr-namespace:CarDealer.UI.HelpersCarDealer.UI.Helpers  5
      &     CarDealer.UI.View.CarFiltersView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      9system&clr-namespace:System;assembly=mscorlib     5      (cclr-namespace:CarDealer.UI     5	      5helper"clr-namespace:CarDealer.UI.Helpers     5
        � 	Resources  5         dataFromEnum S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName-   'CarDealer.UI.Helpers.IntToTextConverter  IntToTextConverter��%�   &	        &	 s     S� 5   
   $ 	GetValues��62   "  6I    5      M� 5      $ helper:SortBySalesEnum��6   5        5   
   6$   5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��2* �6'    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+      �� $��10(�6   $��Center=�6&   $��0��6A   $��Manufacturer:��6Q   $
��10 5q�6i   �� 5,      $��1��6   $	��170��6*   $
��10 5q�5-   C   ��5,   6   �� *Manufacturer+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�5-   C   �� 5/      $��10(�6   $��Center=�6&   $��0��6A   $��1��6Q   $��Model:��6^   $
��10 5q�6o   �� 50      $��1��6   $��1��6*   $	��170��67   $
��10 5q�51   C   ��50   C   �� *Model+$ TwoWay=�$	 PropertyChanged=�51   C   �� 52      $��10(�6   $��Center=�6&   $��0��6A   $��2��6Q   $��
Body Type:��6^   $
��10 5q�6s   �� 53      $��1��6   $��2��6*   $	��170��67   $
��10 5q�54   C   ��53   C   �� *
BodyType+$ TwoWay=�$	 PropertyChanged=�54   C   �� 55      $��10(�6   $��Center=�6&   $��0��6A   $��3��6Q   $��Engine Size:��6^   $
��10 5q�6u   �� 56      $ 
Horizontal=�6   $��1��66   $��3��6F   .+�57      �� $��10(�6   $��Center=�6*   $
��from��6E   �� 59      $��50��6   $
��10 5q�6)   .��67   .��5:      �� 
 �� Path$
 EngineSizeMin�6"   $	 PropertyChanged=�5;      $ TwoWay=�64    �� TargetNullValue$  ��6B    �� 	Converter# [ 6U    �� ValidationRules 5<      "  CarDealer.UI.ValidationRules  5=   "      Type$ filter��64   5?      5@      �� 5A      $��10(�6   $��Center=�6*   $��to��6E   �� 5B      $��50��6   $
��10 5q�6)   .��67   .��5C      �� $
 EngineSizeMax�6"   $	 PropertyChanged=�5D      $ TwoWay=�64   $  ��6B   # [ 6U    5E        5F   "   $ filter��64   5H      5I      5J      �� 5K      $��10(�6   $��Center=�6&   $��0��6A   $��4��6Q   $��Model Year:��6^   $
��10 5q�6t   �� 5L      $ 
Horizontal=�6   $��1��66   $��4��6F   .+�5M      �� $��10(�6   $��Center=�6*   $
��from��6E   �� 5N      $��50��6   $
��10 5q�6)   .��67   .��5O      �� $
 ManufactureYearMin�6"   $	 PropertyChanged=�5P      $ TwoWay=�64   $  ��6B   # [ 6U    5Q        5R   "   $ filter��64   5T      5U      �� 5V      $��10(�6   $��Center=�6*   $��to��6E   �� 5W      $��50��6   $
��10 5q�6)   .��67   .��5X      �� $
 ManufactureYearMax�6"   $	 PropertyChanged=�5Y      $ TwoWay=�64   $  ��6B   # [ 6U    5Z        5[   "   $ filter��64   5]      5^      5_      �� 5`      $��10(�6   $��Center=�6&   $��0��6A   $��5��6Q   $��Transmission:��6^   $
��10 5q�6v   �� 5a      $��1��6   $��5��6*   $	��170��67   $
��10 5q�5b   C   ��5a   C   �� *Transmission+$ TwoWay=�$	 PropertyChanged=�5b   C   �� 5c      $��10(�6   $��Center=�6&   $��0��6A   $��6��6Q   $��Mileage:��6^   $
��10 5q�6q   �� 5d      $ 
Horizontal=�6   $��1��66   $��6��6F   .+�5e      �� $��10(�6   $��Center=�6*   $
��from��6E   �� 5f      $��50��6   $
��10 5q�6)   .��67   .��5g      �� $
 
MileageMin�6"   $	 PropertyChanged=�5h      $ TwoWay=�64   $  ��6B   # [ 6U    5i        5j   "   $ filter��64   5l      5m      �� 5n      $��10(�6   $��Center=�6*   $��to��6E   �� 5o      $��50��6   $
��10 5q�6)   .��67   .��5p      �� $
 
MileageMax�6"   $	 PropertyChanged=�5q      $ TwoWay=�64   $  ��6B   # [ 6U    5r        5s   "   $ filter��64   5u      5v      5w      �� 5x      $��10(�6   $��Center=�6&   $��0��6A   $��7��6Q   $��Colour:��6^   $
��10 5q�6p   �� 5y      $��1��6   $��7��6*   $	��170��67   $
��10 5q�5z   C   ��5y   C   �� *Colour+$ TwoWay=�$	 PropertyChanged=�5z   C   �� 5{      $��10(�6   $��Center=�6&   $��0��6A   $��8��6Q   $��Asking Price:��6^   $
��10 5q�6v   �� 5|      $ 
Horizontal=�6   $��1��66   $��8��6F   .+�5}      �� $��10(�6   $��Center=�6*   $
��from��6E   �� 5~      $��50��6   $
��10 5q�6)   .��67   .��5      �� $
 AskingPriceMin�6"   $	 PropertyChanged=�5�      $ TwoWay=�64   $  ��6B   # [ 6U    5�        5�   "   $ filter��64   5�      5�      �� 5�      $��10(�6   $��Center=�6*   $��to��6E   �� 5�      $��50��6   $
��10 5q�6)   .��67   .��5�      �� $
 AskingPriceMax�6"   $	 PropertyChanged=�5�      $ TwoWay=�64   $  ��6B   # [ 6U    5�        5�   "   $ filter��64   5�      5�      5�      �� 5�      $��10(�6   $��Center=�6&   $��0��6A   $��9��6Q   $��Sort by Sales:��6^   $
��10 5q�6w   �� 5�      $��1��6   $��9��6+   $
��10 5q�6�   ��68   ��  �� Source# [   �� SelectedItem 6u   �� *SortByPopularity+6�   �� 5�      $��10(�6   $��Center=�6&   $��0��6A   $��10��6Q   $��Number of cars:��6_   $
��10 5q�6y   �� 5�      $��1��6   $��10��6*   $	��170��68   $
��10 5q�6D   .��6R   .��5�      �� $
 NumberOfCars�6   $	 PropertyChanged=�5�      $ TwoWay=�64   $  ��6B   # [ 6U    5�        5�      $ filter��60   5�      5�      5�      5�      5�      5�      