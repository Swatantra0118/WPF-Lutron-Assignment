   M S B A M L   `   `   `  ����O  KLutronOrderingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:LutronOrderingSystem.HelpersLutronOrderingSystem.Helpers  5   	   G(clr-namespace:LutronOrderingSystem.ViewsLutronOrderingSystem.Views  5   	   Q-clr-namespace:LutronOrderingSystem.ViewModelsLutronOrderingSystem.ViewModels  5   	   -    'LutronOrderingSystem.Views.ProductsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =helper*clr-namespace:LutronOrderingSystem.Helpers     5   	   :local(clr-namespace:LutronOrderingSystem.Views     5   	   D
viewmodels-clr-namespace:LutronOrderingSystem.ViewModels     5   	     � Title$  Lutron Ordering System��5   	   $	��450��6(   $	��800��65    � 	Resources 5          BooleanToVisibilityConverter:   4LutronOrderingSystem.Helpers.Int32ToBooleanConverter  Int32ToBooleanConverter��%:   &	        &	      �� 5   
   6'     5   
   6)   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   $	��Top=�6<   $��10q�6T   .+�5      �� $��Control Stations��6   $��0,0,0,0q�6_   ��60   �� *ShowControlStationsCommand+6_   �� 5      $��
Enclosures��6   ��6*   �� *ShowEnclosuresCommand+5      � 5   
   $��1��6    � RowDefinitions 5      �� 5       $��* �6    .+�5$      &   System.Windows.Controls.DataGrid  $��0��6      
IsReadOnly . $��0,40,0,0q�66      AutoGenerateColumns .  y�6H   �� *IsControlStationsVisible+ �� 	Converter# [  ��5%      �� *ControlStations+   RowStyle 5&      �� 5'      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   
 �� Triggers
 5(      �� 5*       �� Binding 6*   �� *
Quantity+# [  �� Value True6{   .a�5+   "   ��  �� Property � �� �� Value
 �  ��6?   5,      5.         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Model ID��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	ModelId+6W     52      $ Model Display String��6)    6G   �� *ModelDisplayString+  53      $ Description��6)    6>   �� *Description+  54      $ Number of Buttons��6)    6D   �� *NumberOfButtons+  55      $ Quantity��6)    6;   �� *
Quantity+4  .System.Windows.Controls.DataGridTemplateColumn  58      $ Edit/Delete��6-      CellTemplate 59      �� 5:      .R�5;   "   �� $ 
Horizontal=�6-   .+�5<   &   �� $
��Edit��6-   $��5q�6<   ��6G   �� *DataContext.EditCommand+ �� RelativeSource ��  �� AncestorType$ DataGridL���6�   �� �� 5=   &   $��Delete��6-   $��5q�6>   ��6I   �� *DataContext.DeleteCommand+ �� $ DataGridL���6�   �� *	ModelId+5>   #   5?      5A        5D      $ Add to Cart��6-    5E      �� 5F      .R�5G   "   �� $��Add to Cart��6)   $��5q�6?   ��6J   �� *DataContext.AddToCartCommand+ �� $ DataGridL���6�   �� *	ModelId+5H      5J      5L        5O      $��0��6    . $��0,40,0,0q�66    .  y�6H   �� *IsEnclosuresVisible+# [  ��5P      �� *
Enclosures+ 5Q      �� 5R      "	  6   
 5S      �� 5T       6*   �� *
Quantity+# [  True6{   .a�5U   "   ��  � ��
 �  ��6?   5V      5X       5Z        5[      $ Model ID��6)    6;   �� *	ModelId+  5\      $ Model Display String��6)    6G   �� *ModelDisplayString+  5]      $ Description��6)    6>   �� *Description+  5^      $ 
Mount Type��6)    6=   �� *	MountType+  5_      $ Quantity��6)    6;   �� *
Quantity+  5b      $ Edit/Delete��6-    5c      �� 5d      .R�5e   "   �� $ 
Horizontal=�6-   .+�5f   &   �� $
��Edit��6-   $��5q�6<   ��6G   �� *DataContext.EditCommand+ �� $ DataGridL���6�   �� �� 5g   &   $��Delete��6-   $��5q�6>   ��6I   �� *DataContext.DeleteCommand+ �� $ DataGridL���6�   �� *	ModelId+5h   #   5i      5k        5n      $ Add to Cart��6-    5o      �� 5p      .R�5q   "   �� $��Add to Cart��6)   $��5q�6?   ��6J   �� *DataContext.AddToCartCommand+ �� $ DataGridL���6�   �� *	ModelId+5s      5u      5w      �� 5x      $��
Add Device��6   $
��Left=�6*   $	��Top=�6E   $��10,10,10,10q�6|   ��6]   �� *
AddCommand+6|   �� 5{      $��	Show Cart��6   $��Right=�6)   $	��Top=�6E   $��10,10,10,10q�6]   ��6r   �� *DataContext.ShowCartCommand+ �� $ WindowL�5~      5      5�      