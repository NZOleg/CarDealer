   M S B A M L   `   `   `  ����G  CCarDealer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.UI.ViewCarDealer.UI.View  5      $    CarDealer.UI.View.CheckoutView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarDealer.UI.View     5      .��5	      � .+�5
   
   �� $��Center=�6   $��Center=�62   .+�5      �� $2��,Price must be more than 80% of asking price!��6   $��Center=�6K   $��14(�6h   
���  ��$
��Bold"�6�   y�6�   �� *InvalidPriceVisibility+�� 5        �� Orientation$  
Horizontal=�6   .+�5      �� $��Asking price:$��6   $��Center=�61   $��14(�6N   
���  ��$
��Bold"�6m   y�6   �� *InvalidPriceVisibility+�� 5      $��Center=�6<   $��14(�6Y   
���  ��$
��Bold"�6x   ��6   �� *Car.AskingPrice+y�6�   �� *InvalidPriceVisibility+5      �� 5      $��Price��6   �� 5      $��5q�6   $��34��6!    �� TextWrapping$
 Wrap=�6-   $	��240��6e   ��6A   �� *Price+ �� Mode$ TwoWay=�6e   �� 5      $
��Date��6   (  "System.Windows.Controls.DatePicker  5      $��Center=�6E   $��34��6b   $��Center=�6n   $	��240��6�      SelectedDate 6   �� *Date+$ TwoWay=�6�   �� 5      $	��Buy��6   $��75��6E   $��10q�6P   ��6#   �� *BuyCarCommand+6P   5      5      5      