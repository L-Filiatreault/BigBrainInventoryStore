   M S B A M L   `   `   `  ����N  JFinal-Project-LF-EO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Final_Project_LF_EOFinal_Project_LF_EO  5   	   '    !Final_Project_LF_EO.Remove_Window   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Final_Project_LF_EO     5   	     � Title$  🧠 Remove Window��5   	   $	��300��6)   $	��500��66    � 
ResizeMode$ NoResize=�6B   .��5	      � 
����d� J� RenderTransformOrigin$ 0.413,0.515&�6'    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��450 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��Remove Item��6   $��1��6'   $��0��67   $
��Bold"�6D   $��32(�6V   $��Center=�6d   $��Center=�6�   �� 5   
   $��Item to Remove��6   $��1��6*   $��1��6:   $��Center=�6H   $	��Top=�6e   $
��Bold"�6}   $��20(�6�   �� 5   
   -   5         ��Name$ txtItemRemove��5      $��1��6D   $��1��6T   $	��300��6a   $��30��6m   $��10,25,10,10q�6y   $��1q�6�   $��Center=�6�   $��Center=�6�   
�������$��5,5,5,5q�6�   ��6)   �� *
ItemName+6�   �� 5    
   -   5        $��Remove��5       $��1��6:   $��2��6J   $
��Bold"�6W   $��50��6i   $	��110��6u   $��15(�6�   $��10q�6�   
������� � 	Resources 5!       �� 
TargetType �� Property	 �� Value��%_   '��       �� 5"      " ��6   .�5#      ��  �@��CornerRadius$	 10��65   5$      5%      5&      5'      5)      