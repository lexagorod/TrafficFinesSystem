   M S B A M L   `   `   `  ���� L  HTrafficFineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TrafficFineSystemTrafficFineSystem  A%clr-namespace:TrafficFineSystem.ViewsTrafficFineSystem.Views  $    TrafficFineSystem.PoliceWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:TrafficFineSystem     7views%clr-namespace:TrafficFineSystem.Views       � WindowStartupLocation$  CenterScreen=� � Title$ PoliceWindow��$	��300��$	��600�� � 
ResizeMode$ NoResize=����	#FFC2D1A9$��10,10,10,10q�.���� .+���  �� CornerRadius$ 5,5,5,5��$��3,3,3,3q����	#FF256C18��Z� ._�� -   $��gvAddViolator�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��18(�$��0��$��10q�$��Номерной знак��*   $TrafficFineSystem.Views.TextInputBox  -     Name$ 	txtNumber��   TextBoxErrorStyleName$ TextBoxStyle��   BoundPropertyName$ Number��$��1��$��0��$��20��$
��Auto��$��10q�	   ValidationRules	 4   .TrafficFineSystem.SpecialSymbolsValidationRule  
   ErrorMessage$O
 IНомерной знак не содержит спец символов��1   +TrafficFineSystem.PlateNumberValidaitonRule     ErrorMessage$V PНомерной знак должен быть 6 символов в длину��4   .TrafficFineSystem.NotNullOrEmptyValidationRule     ErrorMessage$G AНомерной знак не должен быть пустым���� $��0��$��1��$��18(�$��10q�$��Имя��  -   $ txtName��$��1��$��1��$��20��$
��Auto��$��10q�$
 Name��	   $4 .Имя не должно быть пустым���� $��0��$��2��$��18(�$��10q�$��Нарушение���� -   $��violationsList��$��20��$
��Auto��$��1��$��2���� -    ��Name$ addingResult��$��2��$��4��$��18(�$��10q�
���  ���� -   $!��Добавить штраф��$
��Auto��$��10q�$��1��$��4��$��18(����	#00052302$��0,0,0,0q����	#FF49A51B���	#FF280B36�� -   $��errorsPanel��.+��� $
��Auto��$ 3,3,3,3��
���  ��$��5q�._��� -    ��Name$ 	errorList������ .R��� $��18(�����  �� Path$ Message�