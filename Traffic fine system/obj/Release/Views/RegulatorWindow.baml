   M S B A M L   `   `   `  ���� L  HTrafficFineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TrafficFineSystemTrafficFineSystem  '    !TrafficFineSystem.RegulatorWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:TrafficFineSystem       � WindowStartupLocation$  CenterScreen=� � Title$ RegulatorWindow��$	��450��$	��800��.��� .+��  � ColumnDefinitions �� $
��Auto � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -     Name$ 	FinesInfo��$��0���� -   $��
SaveButton��$��1��$
��Left=�$��Сохранить�� �� 	ClickMode$ Release=�$��70��$��50���� -    ��Name$ changeSuccess��$��2��$
��Left=�$��18(�$��10q�