   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarDealer.UICarDealer.UI  5      5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      ;"clr-namespace:CarDealer.UI.HelpersCarDealer.UI.Helpers  5      '    !CarDealer.UI.View.SaleFiltersView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (cclr-namespace:CarDealer.UI     5      1localclr-namespace:CarDealer.UI.View     5      5helper"clr-namespace:CarDealer.UI.Helpers     5        � 	Resources  5      -   'CarDealer.UI.Helpers.IntToTextConverter   IntToTextConverter��%   &	          5   
   6$   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Select a month:��6   $��Center=�6*   $��10(�6E   &   System.Windows.Controls.Calendar  5   
   -   5          Name$ 	_calendar��5   0   $��0��6   $��1��6    $��Center=�5         DisplayMode$ Month=�6�      DisplayDate 64   �� *SelectedMonth+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�   SelectedDate 6�   �� *SelectedMonth+$ PropertyChanged=�$ TwoWay=�6�   �� 5   
   $��0��6   $��2��6    $��1��64   $��Center=�6A   $��Center=�6^   $��30(�6y   $
��Bold"�6�   $��OR��6�   �� 5   
   $��10(�6   $��Sales in Range:��6   $��2��68   $��Center=�6F   �� 5   
   	 �� Orientation$	 Vertical=�6   $��2��6,   $��1��69   .+�5       �� .+�5!      �� $��10(�6   $��Center=�6&   $��from:��6A   (  "System.Windows.Controls.DatePicker  5"      $��3��6   $��20(�6+   $��1��6:   $	��150��6J   $
��10 5q�6�   
   SelectedDate
 6V   �� *	StartDate+$ TwoWay=�$ PropertyChanged=�6�   5#      �� 5$      $��10(�6   $��Center=�6    $	��to:��6;     5%      $��3��6   $��20(�6&   $��1��65   $	��150��6E   $
��10 5q�6�   
 6Q   �� *	EndDate+$ TwoWay=�$ PropertyChanged=�6�   5&      5'      5(      