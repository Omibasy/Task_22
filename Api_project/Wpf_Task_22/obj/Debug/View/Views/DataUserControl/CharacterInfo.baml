   M S B A M L   `   `   `  ����F  BWpf_Task_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Wpf_Task_22.View.Views.DataUserControl&Wpf_Task_22.View.Views.DataUserControl  5      :    4Wpf_Task_22.View.Views.DataUserControl.CharacterInfo   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:Wpf_Task_22.View.Views.DataUserControl     5      .��5
      � 
�������  � RowDefinitions  5   
   �� 5      �� 5      .+�5   
   ]� ��. $��20q�5      $��0��5      .+�5      �� ��6   ��  �� Path$ box.HepfImg��� 5      $
��Left=�6   $
��Left=�5      $��50 0 0 0q�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0 0 0 20q�5      .+�5      �� $��Имя:��6    $��14(�5       $��
0 0 50.5 0q�5       ���	#FF495D705!       �� 5#      $��14(�5$       $��40��5%       ��5#       �� $ box.Data.PersonID.Name�5%       5&      �� 5'      $ 
Horizontal=�6   $��0 0 0 20q�5(      .+�5*      �� $��Фамилия:��6    $��14(�5+       $��0 0 20 0q�5,       ���	#FF495D705-       �� 5/      $��14(�50       $��40��51       ��5/       �� *box.Data.PersonID.Surname+51       53      �� 54      $ 
Horizontal=�6   $��0 0 0 20q�55      .+�57      �� $��Отчество:��6    $��14(�58       $��
0 0 18.5 0q�59       ���	#FF495D705:       �� 5<      $��14(�5=       $��40��5>       ��5<       �� *box.Data.PersonID.Patomic+5>       5@      �� 5A      $ 
Horizontal=�6   $��0 0 0 20q�5B      .+�5D      �� $��Телефон:��6    $��14(�5E       $��
0 0 22.5 0q�5F       ���	#FF495D705G       �� 5I      $��14(�5J       $��40��5K       ��5I       �� *box.Data.PhoneNumber+5K       5M      �� 5N      $ 
Horizontal=�6   $��0 0 0 20q�5O      .+�5Q      �� $��Адрес:��6    $��14(�5R       $��0 0 39 0q�5S       ���	#FF495D705T       �� 5V      $��14(�5W       $
��Wrap=�5X       $��40��5Y       ��5V       �� *box.Data.Address+5Y       5Z      5[      5\      ]� 5]   
   $��1��6   $��20q�5^      .+�5`      �� $��Описание:��6   $��22(�5a      $��	20 0 0 10q�5b      ���	#FF495D70$	��Top=�5d      �� 5f      $��18(�5g      $
��Wrap=�5h      ��5f      �� *box.Data.Description+5h      5i      5j      5k      