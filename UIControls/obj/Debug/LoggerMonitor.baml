   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UIControls
UIControls  5      3clr-namespace:UIControls.UtilsUIControls.Utils  5	          UIControls.LoggerMonitor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:UIControls     5      0utilsclr-namespace:UIControls.Utils     5	        � DataContext  5
      ��  �� RelativeSource �� *Self+ � 	Resources 5      .   (UIControls.Utils.LogItemBgColorConverter   LogItemBgColorConverter.   (UIControls.Utils.LogItemFgColorConverter  LogItemFgColorConverter��%:   &	        &	        5   
   6(     5   
   6(   5      .��5      � .+�5   
   �� -   5        $��logView��5   9    %� IsVirtualizing . $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      &    UIControls.Utils.ListBoxBehavior   ScrollOnNewItem . ��5      �� *LogCollection+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@�ToolTip �� Value 60   �� *FormattedMessage+�� 5       � �� 63   �� *Level+	 �� 	Converter#	 [  �� 5       � �� 63   �� *Level+#	 [ 
 �� Triggers
 5      P� 5       P� Property �@��
IsSelected P� Value . . �5      ��  � ��
 � ���6;   �� 5       � ��
 �   �6;   5      P� 5       �@J�IsMouseOver . . �5       ��  � �� 6;   ��  �� *Self+ �� Path$ 
Background��� 5!       � �� 6;   ��  �� *Self+$ 
Foreground�5"      5$       �� View 5&      �� 5'      P�5(      �� 5*      $��Level��6P    �� DisplayMemberBinding 6)   �� *Level+6P   �� 5+      $
��Time��6x    6)   �� *	TimeStamp+	 '   !UIControls.Utils.DateTimeToString  6x   �� 5,       �� Width$	 500��6[   $��Message��6g    6)   �� *FormattedMessage+6g   �� 5-      $��	Exception��6T    6)   �� *	Exception+6T   5/      51      53      54      