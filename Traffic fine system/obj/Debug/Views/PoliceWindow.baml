   M S B A M L   `   `   `  ����L  HTrafficFineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TrafficFineSystemTrafficFineSystem  5   	   A%clr-namespace:TrafficFineSystem.ViewsTrafficFineSystem.Views  67   $    TrafficFineSystem.PoliceWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TrafficFineSystem     5   	   7views%clr-namespace:TrafficFineSystem.Views     67     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ PoliceWindow��5	      $	��300��6   $	��600��6'    � 
ResizeMode$ NoResize=�5
      ���	#FFC2D1A9$��10,10,10,10q�6;   .��5      �� .+�5   
   ��  �� CornerRadius$ 5,5,5,5��6'   $��3,3,3,3q�6>   ���	#FF256C18��6   Z� ._�5      � -   5        $��gvAddViolator��5       � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   �� 5      $
��Auto �6'   66   �� 5      $
��Auto �6'   66    � RowDefinitions 5      �� 5      $
��Auto �6$   64   �� 5      $
��Auto �6$   64   �� 5      $
��Auto �6$   64   �� 5      $
��Auto �6$   64   .+�5      �� $��0��6   $��18(�6,   $��0��6:   $��10q�6G   $��Номерной знак��6S   *   $TrafficFineSystem.Views.TextInputBox  5       -   5          Name$ 	txtNumber��5    e      TextBoxErrorStyleName$ TextBoxStyle��6%      BoundPropertyName$ Number��6J   $��1��6x   $��0��6�   $��20��6�   $
��Auto��6�   $��10q�6�   	   ValidationRules	 5#      4   .TrafficFineSystem.SpecialSymbolsValidationRule  
   ErrorMessage$O
 IНомерной знак не содержит спец символов��6=   1   +TrafficFineSystem.PlateNumberValidaitonRule  5$         ErrorMessage$V PНомерной знак должен быть 6 символов в длину��6:   4   .TrafficFineSystem.NotNullOrEmptyValidationRule  5%         ErrorMessage$G AНомерной знак не должен быть пустым��6=   5)      �� 5+      $��0��6   $��1��6,   $��18(�69   $��10q�6G   $��Имя��6S     5-      -   5        $ txtName��5-   h   $��1��6%   $��1��66   $��20��6C   $
��Auto��6O   $��10q�6\   $
 Name��6y   	 50        $4 .Имя не должно быть пустым��6=   53      �� 55      $��0��6   $��2��6,   $��18(�69   $��10q�6G   $��Нарушение��6S   �� 57      -   5        $��violationsList��57      $��20��61   $
��Auto��6=   $��1��6J   $��2��6Z   58      �� 5:      -   5         ��Name$ addingResult��5:      $��2��62   $��4��6B   $��18(�6O   $��10q�6]   
���  ��6i   �� 5<      -   5        $!��Добавить штраф��5<      $
��Auto��6R   $��10q�6_   $��1��6l   $��4��6|   $��18(�6�   ���	#00052302$��0,0,0,0q�6�   ���	#FF49A51B���	#FF280B366�   5>      5?      �� 5B   
   -   5        $��errorsPanel��5B      .+�5C      �� $
��Auto��6   $ 3,3,3,3��6"   
���  ��$��5q�6K   ._�5E      �� -   5         ��Name$ 	errorList��5E      ��5F      �� 5G      .R�5H      �� $��18(�6(   ��66   ��  �� Path$ Message�5I      5K      5L      5M      5Q      5R      