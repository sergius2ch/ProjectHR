   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:UIControls.ToastsUIControls.Toasts 5      'clr-namespace:UIControls
UIControls 5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ToastColourSuccess  ToastColourInfo  ToastColourWarning  ToastColourDanger)   #UIControls.Toasts.ToastNotification  �� 
TargetType �� BasedOn �� 	Resources  Key �� 
TargetName g� Duration �� TargetProperty W� From	 W� To W� EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase	   
EasingMode-  'System.Windows.Media.Animation.BackEase
   	Amplitude �� Property �� Value �� 
TargetType � ColumnDefinitions    Title    FontSizeTitle    Message ��Name � Cursor �� Padding � Points  	LeftArrow  
RightArrow  UpArrow  	DownArrow 	 SearchTextBox_Background �� Color 
 SearchTextBox_Foreground  SearchTextBox_Border �� 
StartPoint �� EndPoint � Color � Offset ! SearchTextBox_BorderMouseOver " SearchTextBox_SearchIconBorder & "SearchTextBox_SearchIconBackground , (SearchTextBox_SearchIconBorder_MouseOver 0 ,SearchTextBox_SearchIconBackground_MouseOver , (SearchTextBox_SearchIconBorder_MouseDown 0 ,SearchTextBox_SearchIconBackground_MouseDown   SearchTextBox_LabelTextColor  UIControls.SearchTextBox ��Name �Name ��Name ��Name �� RelativeSource  �� Path! ��Name" � ToolTip# �� Triggers$ P� 
SourceName% P� Property& P� Value' �� 
TargetName( ]� 
Conditions) �� Property* �� Value  UIControls.LabelUpDown+ F�Name, �� Stretch�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      RmwtJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5      )toatsclr-namespace:UIControls.Toasts  5      lclr-namespace:UIControls  5      %x#  &	        &	      &	 >     &	 ]     '   |     7��7   7  7  7  &	 q
    &	 �
    &	 �
    &	 6    &		 w    &	
 �    &	 �    &	 �    &	 Q    &	 p    &	 �    &	 '    &	 $    &	 �    &	 �    '  �    7 	 7  7 
 7  7  7  7  7  7  '  �    7 	 7  7 
 7  7  7  ��5	      #3fb618��6:   ��5
      #9954bb��67   ��5      #ff7518��6:   ��5      #ff0039��69   �� 5      "    6   8    5   
   ���� 5      ToastScaleInStoryboard  5      �� .��5      W� $ 0:0:0.25D�5      $ Opacity�5      $	 0.3X�5      $ 1X�6    5        5      $	 EaseOut=�6$   5      W� 5      $- 'RenderTransform.(ScaleTransform.ScaleX)�6"   $ 0X�5   	   $ 1X�6   $ 0:0:0.3D�5   	    5        5      $	 EaseOut=�6#   $	
 0.3Q�5      5!      W� 5"      $- 'RenderTransform.(ScaleTransform.ScaleY)�6"   $ 0X�5#   	   $ 1X�6   $ 0:0:0.3D�5$   	    5%        5&      $	 EaseOut=�6#   $	
 0.3Q�5'      5)      5*      5+      .�5,   
   ��  � ��$ 80��6%   �� 5-   
    � ��$ 60��6&   �� 5.   
    �@J�RenderTransformOrigin$ 1.0,0.5&�62   �� 5/   
    � ��$ Calibri)�6'   �� 50   
    �@  FontSizeTitle$ 18Q�6*   �� 51   
    � ��$ 14(�6%   �� 52   
    � ��
 �����6'   �� 53   
    �@  ColourSuccess8  6*   �� 54   
    �@  ColourDanger8  6)   �� 55   
    �@  
ColourInfo8  6'   �� 56   
    �@  ColourWarning8  6*   �� 57   
    � z� 58      �� 59      5;      �� 5<   
    � �� 5=      �� 5>      "   6"   .R�5?      � $��0,0,0,6q�6    5@      �� 5A      $��* �6/   �� 5B      $
��Auto �6/   .+�5E      �� $��0q�6!   #��z��65   ._�5F      �  5G   "   �� 5H   &   $��* �67   �� 5I   &   $
��Auto �67   �� 5J   &   $
��Auto �67   .+�5M   "   �� $��0��6-   $��Center=�5N      $��10q�5O      .+�5P   &   �� #��z 60   #��z 5Q      #��z��5R      $
��Wrap=�5S      #��z��5T      $
��Bold"�5U      �� 5V   &   #��z 60   $��0,3,0,0q�5W      #��z��5X      #��z��5Y      $
��Wrap=�5Z      #��z��5[      5\   #   �� 5^   "   $ PART_DismissButton��5e      $��1��5^   )   
������ $
 Hand��5`      $
��10,5q�5a      $��3q�5b      $��1(�5c      $��0q�5d      ��5f   &   �� 5g   *   "  ��60   .�5h   .   ��  � �� 5i   2   �� 5j   6   " ��6F   .R�5k   :   �� #��z��6A   # z��6k   ._�5l   >   �� $��Center=�6O   $��Center=�6l   5m   ;   5n   7   5p   /   5q   +   .��5s   &   �� $"��/Images/Icons/CrossWhite.png��6,   $��18��6R   $��18��6]   5t   #   5u      5v      (� 5x      $��1��6"   $��24��5y   
   $��Center=�5z   
   $��-1,0,0,0q�5{   
   .��5|      �  �    z @KL ��� 
������ #��z��6R   5}      5~      5      5�      5�      ��5�      .*M0,25 L25,0 25,13 50,13 50,37 25,37 25,50z�6S   ��5�      -)M50,25 L25,0 25,13 0,13 0,37 25,37 25,50z�6S   ��5�      .*M25,0 L0,25 13,25 13,50 37,50 37,25 50,25z�6Q   ��5�      -)M25,50 L0,25 13,25 13,0 37,0 37,25 50,25z�6R   �� 5�      $ White��67   �� 5�      $ Black��65   �� 5�      $	 0,0&�65   $	 0,1&�6F   .��5�      � $ 	#FFABADB3��6   $
 0.05Q�6%   � 5�      $ 	#FFE2E3EA��6   $
 0.07Q�6%   � 5�      $ 	#FFE4E9EF��6   $ 1Q�6%   5�      �� 5�      $	 0,0&�6>   $	 0,1&�6O   .��5�      � $ 	#FF5C97C1��6   $
 0.05Q�6%   � 5�      $ 	#FFB9D7EB��6   $
 0.07Q�6%   � 5�      $ 	#FFC7E2F1��6   $ 1Q�6%   5�      �� 5�      $ White��6;   �� 5�      $ White��6?   �� 5�      $	 0,0&�6I   $	 0,1&�6Z   .��5�      � $ 	#FFFFFFFF��6   $ 0Q�6%   � 5�      $ 	#FFE5F4FC��6   $ 1Q�6%   5�      �� 5�      $	 0,0&�6M   $	 0,1&�6^   .��5�      � $ 	#FFE7F5FD��6   $ 0Q�6%   � 5�      $ 	#FFD2EDFC��6   $	 0.5Q�6%   � 5�      $ 	#FFB6E3FD��6   $
 0.51Q�6%   � 5�      $ 	#FF9DD5F3��6   $ 1Q�6%   5�      �� 5�      $	 0,0&�6I   $	 0,1&�6Z   .��5�      � $ 	#FFFFFFFF��6   $ 0Q�6%   � 5�      $ 	#FFE5F4FC��6   $ 1Q�6%   5�      �� 5�      $	 0,0&�6M   $	 0,1&�6^   .��5�      � $ 	#FFE7F5FD��6   $ 0Q�6%   � 5�      $ 	#FFD2EDFC��6   $	 0.5Q�6%   � 5�      $ 	#FFB6E3FD��6   $
 0.51Q�6%   � 5�      $ 	#FF9DD5F3��6   $ 1Q�6%   5�      �� 5�      $
 Gray��69   �� 5�      "   6+   .�5�      ��  � ��8   6#   �� 5�       � ��8  6$   �� 5�       � ��8  6#   �� 5�       � ��$ 1q�6(   �� 5�       �@J�SnapsToDevicePixels . 6,   �� 5�       �@ 	LabelText$ Search��6"   �� 5�       �@�FocusVisualStyle 6)   Z� �� 5�       �@ LabelTextColor8  6'   �� 5�       � �� 5�      �� 5�   
   "  6   .R�5�      �� $ Border��6   #��z��5�      #��z��5�      #��z��5�      ._�5�      � $ 
LayoutGrid��6    5�      �� 5�      $��* �6+   �� 5�      $
��Auto �6+   �� 5�      $
��Auto �6+   �� 5�      $
��Auto �6+   �� 5�      $
��Auto �6+   .+�5�      �� $ PART_ContentHost��6,   $��2q�6!   $��0��6F   $��Center=�6V   �� 5�      $ 	LabelText��6   $��2q�5�      $��0��5�      $��2,0,0,0q�5�      $��Center=�5�      $��Italic$�5�      ��5�      ��  �� *TemplatedParent+$  LabelTextColor���5�      ��  �� *TemplatedParent+$  	LabelText�5�      �� 5�      $ PART_ClearIconBorder��6+   $��1��6   $��Stretch=�5�      $��Stretch=�5�      8�� ._�5�   "   �� $! 	ClearIcon��6(   $
��None=�5�       $��15��5�       $��15��5�       $��Center=�5�       $��Center=�5�       $B��<pack://application:,,,/UIControls;component/Images/clear.png��5�       $" Click to clear��5�       5�      �� 5�      $ PART_SearchIconBorder��6+   $��2��6   $��Stretch=�5�      $��Stretch=�5�      8�� ._�5�      �� $! 
SearchIcon��6    $
��None=�5�       $��15��5�       $��15��5�       $��Center=�5�       $��Center=�5�       $C��=pack://application:,,,/UIControls;component/Images/search.png��5�       $" Click to search��5�       5�      �� 5�      $ PART_SpecifySearchType��6+   $��3��6   $��Stretch=�5�      $��Stretch=�5�      8�� ._�5�      �� $! SpecifySearchType��6    $
��None=�5�       $��15��5�       $��15��5�       $��Center=�5�       $��Center=�5�       $D��>pack://application:,,,/UIControls;component/Images/Key-Add.png��5       $" Choose section(s)��6h   5     �� 5     $ PART_PreviousItem��6+   $��4��6   $��Stretch=�5     $��Stretch=�5     8�� ._�5     �� $! PreviousIcon��6$   $
��None=�5	     $��15��5
     $��15��5     $��Center=�5     $��Center=�5     $E��?pack://application:,,,/UIControls;component/Images/Previous.png��5     $" Previous keyword(s)��6e   5     5     5     # 5     P� 5     $$ 	LabelText��6:   % �@J�IsMouseOver& . . �5     �� $' 
LayoutGrid��6/    � �� �#F3F9F26G   �� 5      �@�Cursor$ IBeam��6+   5     P� 5     % �@J�IsMouseOver& .  . �5     �� $' 
LayoutGrid��6/    � �� �#DCEED96G   5     P� 5     % �@J�IsKeyboardFocusWithin& . . �5     �� 8   � ��60   5      P� 5"     % �@ HasText& . . �5#     �� $' 	LabelText��6/    � y�$ Hidden=�6F   5$     ]� 5&     ( 5'     �� 5(     ) �@ HasText* .  6/   ./�5*     �� $' 	ClearIcon��5+      � y�$ 	Collapsed=�5,     5-     50     52     53     �� 55     "   6)   .�57  
   ��  � ��8   6'   �� 58  
    � ��8  6(   �� 59  
    � ��8  6'   �� 5:  
    � ��$ 1q�6,   �� 5;  
    �@J�SnapsToDevicePixels . 60   �� 5<  
    �@ 	LabelText$ Label��6&   �� 5=  
    �@�FocusVisualStyle 6-   Z� �� 5>  
    �@ LabelTextColor8  6+   �� 5@  
    � �� 5A     �� 5B     "  6"   .R�5C     �� $ Border��6   ._�5D     � $ 
LayoutGrid��6    5E     �� 5F  "   $��20 �63   �� 5G  "   $
��Auto �63   .+�5J     �� $��0��6%   ��5K  %   Z� ._�5L  "   �� $��3q�6-   .+�5M  &   F� $+ PART_Arrow1��6+   $y�	Collapsed=�5N  +   $��Stretch=�5O  +   $��Stretch=�5P  +   8�� #��z��5R  +   $, Uniform=�6O   F� 5S  &   $+ PART_Arrow2��6+   $��Stretch=�5T  +   $��Stretch=�5U  +   8�� #��z��5W  +   $, Uniform=�6O   5X  #   5Y     �� 5[     $ 	LabelText��64   $��1��6$   $��0,0,0,0q�5^  $   $��Center=�5_  $   ��5\  $   ��  �� *TemplatedParent+$  LabelTextColor���5]  $   ��  �� *TemplatedParent+$  	LabelText�5_  $   5`     5a     5c     5e     5f     5g     