   M S B A M L   `   `   `  ����F  BWpf_Task_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Wpf_Task_22.View.ViewModel.DataModel.SourceModel0Wpf_Task_22.View.ViewModel.DataModel.SourceModel  5   	   q=clr-namespace:Wpf_Task_22.View.ViewModel.DataModel.AdminModel/Wpf_Task_22.View.ViewModel.DataModel.AdminModel  5   	   Y1clr-namespace:Wpf_Task_22.View.Views.AdminControl#Wpf_Task_22.View.Views.AdminControl  5   	   _4clr-namespace:Wpf_Task_22.View.Views.DataUserControl&Wpf_Task_22.View.Views.DataUserControl  5	   	   [2clr-namespace:Wpf_Task_22.View.ViewModel.DataModel$Wpf_Task_22.View.ViewModel.DataModel  5
   	   $    Wpf_Task_22.View.DataPhoneBook   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U
viewmodels>clr-namespace:Wpf_Task_22.View.ViewModel.DataModel.SourceModel     5   	   Xviewadminmodel=clr-namespace:Wpf_Task_22.View.ViewModel.DataModel.AdminModel     5   	   H
viewsadmin1clr-namespace:Wpf_Task_22.View.Views.AdminControl     5   	   Fviews4clr-namespace:Wpf_Task_22.View.Views.DataUserControl     5	   	   Dlocal2clr-namespace:Wpf_Task_22.View.ViewModel.DataModel     5
   	   -   5          � Title$%  Телефонная книга��5   	   $	��700��5   	   $	��800��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      8  2Wpf_Task_22.View.ViewModel.DataModel.MainDataModel  5   
    � 	Resources 5       �� DataTypeC  =Wpf_Task_22.View.ViewModel.DataModel.AdminModel.UserListModel6   0Wpf_Task_22.View.Views.AdminControl.UserListViewB  <Wpf_Task_22.View.ViewModel.DataModel.AdminModel.AddUserModel1   +Wpf_Task_22.View.Views.AdminControl.AddUserD  >Wpf_Task_22.View.ViewModel.DataModel.SourceModel.EditDataModel9   3Wpf_Task_22.View.Views.DataUserControl.EditDataViewE  ?Wpf_Task_22.View.ViewModel.DataModel.SourceModel.EditPhotoModel:	   4Wpf_Task_22.View.Views.DataUserControl.EditPhotoViewJ
  DWpf_Task_22.View.ViewModel.DataModel.SourceModel.CharacterTableModel;   5Wpf_Task_22.View.Views.DataUserControl.CharacterTableC  =Wpf_Task_22.View.ViewModel.DataModel.SourceModel.AddDataModel8   2Wpf_Task_22.View.Views.DataUserControl.AddDataViewI  CWpf_Task_22.View.ViewModel.DataModel.SourceModel.CharacterInfoModel:   4Wpf_Task_22.View.Views.DataUserControl.CharacterInfo �� 
TargetType   ButtonCastom �� Property �� Value��%�  (��       5   5   *, +)(�� Y     5   0   *, +)(�� �     5   5   *, +)(��     5   6   *, +)(�� `    5!   ;   *,
 +)(�� �    5$   4   *, +)(��     5'   ?   *, +)&	  z    �� 5   
   UserListViewTemplate��"  65   .R�5         6&   �� 5      �� 5   
   AddUserTemplate��"  60   .R�5         6!   �� 5      �� 5   
   EditDataViewTemplate��"  65   .R�5         6!   �� 5      �� 5   
   EditPhotoViewTemplate��"  66   .R�5      	   6"   �� 5       �� 5!   
   CharacterTableViewTemplate��" 
 6;   .R�5"         6#   �� 5#      �� 5$   
   AddDataViewTemplate��"  64   .R�5%         6    �� 5&      �� 5'   
   "CharacterInfoModelViewTemplate��"  6?   .R�5(         6"   �� 5)      �� 5*   
   " ��6   .�5+      ��  �@�Cursor$
 Hand��6'   �� 5,       � ��$ 20��6'   �� 5-       � ��$ Center=�62   �� 5.       � ��$ 20��6&   �� 5/       � ��$ 5 0 0 0q�6'   �� 50       � �� �#A1A6B46,   �� 51       � �� �#FFF6+   �� 52       � ��$ 2q�60   53      54      .��55      �  � ColumnDefinitions 56   
   �� 57      $
��0.5* �6   �� 58      $
��0.5* �6   	 � RowDefinitions	 5:   
   �� 5;      $��35 �6   �� 5<      $��5 �6   �� 5=      .+�5?   
   ]� 
�������$��1��5@      $��0��5A      $��2��5B      �� 5C   
   $��0��6   $��0��5D      $��2��5E      $��2q�5F      ���	#FFD4C6C6
 � Cursor$
  ��5G   ,   ._�5H      ��  �� Orientation$ 
Horizontal=�6   ���	#FFF0EDED.+�5J      �� #��[  6   $��15 0 0 0q�5K      $

 Hand��5L   G   ��6   ��  �� Path$ TransitioBackCommand�.��5M      �� $��\Icons\arrow.png��6    � ToolTip 5N      _� 5O      .��6"   
Назад5Q       5S      ��%^   '��       �� 5T      " ��6    .�5U      ��  �@��CornerRadius$ 3��6=   5V      5W      5X      �� 5Z      -   5         ��Name$ 	AddPerson��5\      #��[  5Z      ��5[      �� $ AddDataCommand�.��5]      �� $��\Icons\plus.png��6    5^      _� 5_      .��6"   Добавить запись5a       5c      ��%^   '��       �� 5d      " ��6    .�5e      ��  �@��CornerRadius$ 3��6=   5f      5g      5h      �� 5i      -   5        $ AddUser��5k      #��[  5i      ��5j      �� *AddUserCommand+.��5l      �� $��\Icons\people_plus.png��6    5m      _� 5n      .��6"   ;9Зарегестирровать пользователя5p       5r      ��%^   '��       �� 5s      " ��6    .�5t      ��  �@��CornerRadius$ 3��6=   5u      5v      5w      �� 5x      -   5        $ GetUserList��5z      #��[  5x      ��5y      �� *GetListUserCommand+.��5{      �� $��\Icons\list.png��6    5|      _� 5}      .��6"   /-Загрузить пользователей5       5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 3��6=   5�      5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ RoleUser��5�      $��0��5�      $��1��5�      $��18(�5�      ���	#FFE8B40F$��Right=�5�      $��Center=�5�      $��0 0 20 0q�5�      �� 5�   
   $��2��6   $��0��5�      $��2��5�      ��5�      �� *SelectViewModel+ �� Mode$ TwoWay=�5�      5�      