   M S B A M L   `   `   `  ����F  BWpf_Task_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Wpf_Task_22.View.ViewModel.StaticResources*Wpf_Task_22.View.ViewModel.StaticResources  5      o<clr-namespace:Wpf_Task_22.View.Views.RegistrationUserControl.Wpf_Task_22.View.Views.RegistrationUserControl  5      C    =Wpf_Task_22.View.Views.RegistrationUserControl.EnterPhoneBook   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Fw8clr-namespace:Wpf_Task_22.View.ViewModel.StaticResources     5      Nlocal<clr-namespace:Wpf_Task_22.View.Views.RegistrationUserControl     5      -   5          � 	Resources  5	       �� 
TargetType   CastomButton �� 	Resources �� Property �� Value  ButtonCastom �� 
TargetType �� Triggers P� Property P� Value��%�  &	        &	 �     �� 5
   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 3��65   5      5      5      �� 5   
   " ��6   .�5      ��  � �� �	#FFEDF3F36+   �� 5       � �� �	#FF004EBA6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver . . �5      ��  � �� �	#FF1476FF63   5       P� 5!       �@J�	IsFocused . . �5"      ��  � �� �	#FF32517C63   5#      5%      5&      .��5'      � ���	#FFEDF3F3	 � ColumnDefinitions	 5)   
   �� 5*      
 � RowDefinitions
 5,   
   �� 5-      $��1* �6   �� 5.      $��55 �6   .+�50   
   �� $��	0,10,0,10q�6   $��0��51      $��Center=�52      $	��Top=�53      .+�54      �� $1��+Вход в телефонную книгу��6   $��22(�55      ���	#FF0D0E0F56      �� 57      $��16(�58      $��Center=�59      
���  ��$��0 20 0 0q�5;      ��57      �� *
UserStatus+5;      ]� 5<      $	��220��6   ��. $��0 10 0 0q�5>      .+�5?      �� $��
Логин��6   $��14(�5@      $
��Left=�5A      �� 5B      $��14(�6   $��Right=�5C      $	��150��5D      ��5E      ��  �� Path$ User.loginProp��� 5F      $y�Hidden=�6   $
��Left=�5G      5H      ]� 5I      $	��220��6   ��. $��0 10 0 0q�5K      .+�5L      �� $��Пароль��6   $��14(�5M      $
��Left=�5N      G� 5O      -   5         G�Name$ StrongPassword��5O      $��14(�5P      $	��150��5Q      $��Right=�5R      ?  9Wpf_Task_22.View.ViewModel.StaticResources.PasswordHelper   Attach .    Password 5T      �� *User.password+ �� Mode$ TwoWay=�5U      �� 5V      $y�Hidden=�6   $
��Left=�5W      5X      �� 5Y      -   5        $��0 25 0 0q�5Y      $��0q�5Z      #��[ 5[      $	��150��5]       � Cursor$
 Hand��5^      ��5_      �� 5`      B� 5a      .�6    ,*Войти без аунтификации68   5b      5d      �� 5e      $��0 5 0 10q�6   $��0q�5f      #��[ 5g      $��80��5i      $
 Hand��5j      ��5h      �� $ TransitionCommand���5k      �� 5l      B� 5m      .�6   Регистрация6"   5n      5p      5q      ]� 5r   
   $��10,10,10,10q�6   $��1��5s      $��Bottom=�5t      $��25��5u      .+�5v      �� -   5        $��60��5v      $��Отмена��5w      $
��Left=�5x      #��[  5z      $
 Hand��5{      �� 5|      $��
Войти��6   $��60��5~      $��Right=�5      #��[  5�      $
 Hand��5�      ��5}      �� $ LoginCommand�5�      �� 5�      $y�Hidden=�6   5�      5�      5�      