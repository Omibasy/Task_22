   M S B A M L   `   `   `  ����F  BWpf_Task_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Wpf_Task_22.View.ViewModel.StaticResources*Wpf_Task_22.View.ViewModel.StaticResources  5      o<clr-namespace:Wpf_Task_22.View.Views.RegistrationUserControl.Wpf_Task_22.View.Views.RegistrationUserControl  5      I    CWpf_Task_22.View.Views.RegistrationUserControl.RegistrationViewMain   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Fw8clr-namespace:Wpf_Task_22.View.ViewModel.StaticResources     5      Nlocal<clr-namespace:Wpf_Task_22.View.Views.RegistrationUserControl     5      -   5        $	��270��5        � 	Resources  5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� RelativeSource �� Path   CastomButton	 �� 	Resources  validationFailed
 �� Orientation �� CornerRadius��%8  '��       'G� �     &	  �    &	 x    �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5   
   ��  �� *Self+$&  (Validation.Errors)/ErrorContent��� 5       � ��
 �  ��63   5      5      �� 5   
   " G�6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      ��  �� *Self+$&  (Validation.Errors)/ErrorContent��� 5       � ��
 �  ��63   5      5      �� 5   
   " ��6   	 5       ���� 5!      '��       " ��6   .�5"      ��  �@��CornerRadius$ 3��65   5#      5$      5%      �� 5&   
   .R�5'      �� $
 
Horizontal=�6   .+�5(      �� 
������$��2q�5)      ._�5*      �� 5+      �� 5,      $ 40��6   
�������$��2q�5.      $��5 0 0 0q�5/      $��18��50      $��18��51      ._�52      �� 
���  ��$��16(�53      $��Center=�54      $��Center=�55      $��0 0 0 1q�56      $
��Bold"�57      !61   58      59      5:      5;      .��5<      � ���	#FFEDF3F3 � ColumnDefinitions 5=   
   �� 5>      $��1* �6    � RowDefinitions 5@   
   �� 5A      $��1* �6   �� 5B      $��45 �6   .+�5D   
   �� $��Center=�6   $��Center=�5E      $	��290��5F      .+�5G      �� $��Регистрация��6   $��24(�5H      $��Center=�5I      �� 5J      $��16(�5K      $��Center=�5L      
���  ��$��0 10 0 0q�5N      ��5J      �� *
UserStatus+5N      ]� 5O      ��. $��0 10 0 0q�5P      .+�5R      �� -   5         ��Name$ ComboBoxRegistration��5W       �� SelectedIndex$ 0��5R      $��20 0 0 0q�5S      $	��120��5T      $��Right=�5U      $��23��5V      .@�5X      �� $��
Админ��6    �� 5Y      $��Пользователь��6    5Z      �� 5\      $��
Роль :��6   $��14(�5]      $
��Left=�5^      5_      ]� 5`      ��. $��0 20 0 0q�5a      .+�5c      �� $	��120��6   $��Right=�5d      $��14(�5e       =� ErrorTemplate# [ 5f      .��6T   ��5g      �� 5h      $  userRegistration.LoginProp�6"    �� NotifyOnValidationError .  �� UpdateSourceTrigger$ PropertyChanged=�5j   "    �� Mode$ TwoWay=�5k   "    �� ValidationRules 5l      5  /System.Windows.Controls.DataErrorValidationRule  5m   "   5o      .��5p   $   5q      �� 5r      $��Логин :��6   $
��Left=�5s      $��14(�5t      5u      ]� 5v      ��. $��0 10 0 0q�5w      .+�5x      G� -   5         G�Name$ 
MyPassword��5{      $	��120��5x      $��Right=�5y      $��14(�5z      # [ 5|      ?  9Wpf_Task_22.View.ViewModel.StaticResources.PasswordHelper   Attach .    Password 5~      �� *userRegistration.Password+$ TwoWay=�$ Default=� �� ValidatesOnDataErrors .  �� ValidatesOnExceptions . 5�      �� 5�      $��Пароль :��6   $
��Left=�5�      $��14(�5�      5�      ]� 5�      ��. $��0 10 0 0q�5�      .+�5�      G� $	��120��6   $��Right=�5�      $��14(�5�       . # [ 5�       5�      �� *" userRegistration.ConfirmPassword+$ TwoWay=�$ Default=� .  . 5�      �� 5�      $-��'Потверждение пароля :��6   $
��Left=�5�      $��14(�5�      5�      5�      ]� 5�   
   ��. $��1��5�      $��10q�5�      .+�5�      �� $
��Left=�6   $��Отмена��5�      $��60��5�      #��[  5�      ��5�      �� *BackCommand+�� 5�      $��Right=�6   $	��Oк��5�      $��60��5�      #��[  5�      ��5�      �� $ SendRegistrationCommand���5�      ��  �� ElementName$ ComboBoxRegistration��$ SelectedIndex�$ OneWay=��� 5�      $y�Hidden=�6   5�      5�      5�      