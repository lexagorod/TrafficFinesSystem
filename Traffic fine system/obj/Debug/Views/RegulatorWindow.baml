   M S B A M L   `   `   `  ����L  HTrafficFineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TrafficFineSystemTrafficFineSystem  5   	   '    !TrafficFineSystem.RegulatorWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TrafficFineSystem     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ RegulatorWindow��5	   	   $	��450��6!   $	��800��6.   .��5
      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   62    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	FinesInfo��5      $��0��6*   5      �� 5      -   5        $��
SaveButton��5      $��1��6(   $
��Left=�65   $��Сохранить��6P    �� 	ClickMode$ Release=�6d   $��70��6x   $��50��6�   5      �� 5      -   5         ��Name$ changeSuccess��5      $��2��60   $
��Left=�6=   $��18(�6X   $��10q�6f   5       5"      5#      