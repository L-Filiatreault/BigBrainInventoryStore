   M S B A M L   `   `   `  ����N  JFinal-Project-LF-EO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Final_Project_LF_EOFinal_Project_LF_EO  5   	   &     Final_Project_LF_EO.Shopping_Win   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Final_Project_LF_EO     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 🧠 Shopping List Window��5	   	   $	��450��60   $	��750��6=    � 
ResizeMode$ NoResize=�6I   .��5
      � 
����d� � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��150 �6   �� 5      $	��150 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0��6>   $��3��6L   $��Center=�6a   .+�5      �� $��Shopping List Menu��6   $��32(�62   $
��Bold"�6@   $��0,0,0,0q�6R   $��3��6d   5      � 5   
   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
lbShopping��5      $��0��6+   $��0��6;      AutoGenerateColumns$ False��6H      
IsReadOnly$
 True��6d   $��80,50,100,-250q�6v   $��2��6�   $��Center=�6�      CanUserAddRows$ False��5      	   CanUserDeleteRows$	 False��6.   
   CanUserResizeRows$
 False��6H      CanUserResizeColumns$ False��6b      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Item Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
ItemName+  5      $ Category��6)    6;   �� *CategoryItem+  5       $ Minimum Quantity��6)    6C   �� *MinimumQuantity+  5!      $ Available Quantity��6)    6E   �� *AvailableQuantity+  5"      $ Aisle Number��6)    6?   �� *AisleNumber+  5#      $ 	Supplier ��6)    6<   �� *
Supplier+5%      5&      5)      5*      