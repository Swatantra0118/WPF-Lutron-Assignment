   M S B A M L   `   `   `  ����O  KLutronOrderingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:LutronOrderingSystem.ViewsLutronOrderingSystem.Views  5   	   Q-clr-namespace:LutronOrderingSystem.ViewModelsLutronOrderingSystem.ViewModels  5   	   /    )LutronOrderingSystem.Views.CartWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:LutronOrderingSystem.Views     5   	   D
viewmodels-clr-namespace:LutronOrderingSystem.ViewModels     5   	     � Title$  My Cart��5	   	   $	��450��6   $	��800��6&   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��My Cart��6   $��20(�6#   $
��Bold"�61   $��Center=�6C   $
��0,10q�6`   �� 5   
   $��1��6   ��6   �� *	CartItems+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��
Model ID: ��6$   $��5q�66   �� 5      $��5q�6E   ��6$   �� *Product.ModelId+6E   �� 5      $��Model Display String: ��6$   $��5q�6B   �� 5      $��5q�6P   ��6$   �� *Product.ModelDisplayString+6P   �� 5      $��Description: ��6$   $��5q�69   �� 5      $��5q�6I   ��6$   �� *Product.Description+6I   �� 5      $��
Quantity: ��6$   $��5q�66   �� 5       $��5q�6F   ��6$   �� *Product.Quantity+6F   �� 5!      $��Cart Quantity: ��6$   $��5q�6;   �� 5"      $��5q�6>   ��6$   �� *
Quantity+6>   5#      5$      5&      �� 5)   
   $��Checkout��6   $��1��6$   $��Center=�61   $��Bottom=�6N   $��0,10,0,0q�6i   ��5*      �� *CheckoutCommand+5+      5,      