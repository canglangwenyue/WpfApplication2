   M S B A M L   `   `   `  ����  WpfApplication2     WpfApplication2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          �Name$  window��5   �    � Title$ 南雷皇家技术学院��5   	   $	��308��6   $	��400��6'    � WindowStyle$
 None=�63    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\    � 	Resources 5         Storyboard1  Storyboard2 �� TargetProperty �� 
TargetName g� RepeatBehavior	 �� KeyTime
 �� Value<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value �� KeyTime �� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value R� KeyTime R� Value��%n  &	        &	      �� 5      6   �� 5      .��5	      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6"   $ 	textBlock��6o   $ Forever��6�   .g�5
      p� $	 0��6   $
 Black��6(   p� 5      $	 0:0:1��6   $
 	#FFEA2929��6,   p� 5      $	 0:0:2��6   $
 	#FF29EA48��6,   p� 5      $	 0:0:3��6   $
 	#FFEA298E��6,   p� 5      $	 0:0:4��6   $
 	#FFEA298E��6,   p� 5      $	 0:0:5��6   $
 	#FF141213��6,   p� 5      $	 0:0:6��6   $
 	#FF9C9772��6,   5      r� 5      $ (Border.BorderThickness)�6&   $ window��6[   .	�5        $ 0:0:6��6   $	 2,5q�6.   5      U� 5      $ (FrameworkElement.Width)�6#   $ cancle��6X   .\�5        $ 0:0:6��6   $ 80Q�6+   5      r� 5      $ (Border.BorderThickness)�6&   $ cancle��6[   .	�5        $ 0:0:6��6   $ 0,1,1,1q�6.   5      �� 5      $ (Button.IsCancel)�6$   $ cancle��6R   .p�5      s� $ 0:0:6��6    . 6.   5      �� 5      $ (Button.IsDefault)�6$   $ button��6S   .p�5      s� $ 0:0:6��6    . 6.   5       U� 5!      $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6#   $ cancle��6�   .\�5"        $ 0:0:6��6   $ -1Q�6+   5#      U� 5$      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6#   $ 
textBlock1��6�   .\�5%        $ 0:0:6��6   $ 4.707Q�6+   5&      U� 5'      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6#   $ button��6�   .\�5(        $ 0:0:6��6   $ -0.119Q�6+   5)      U� 5*      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6#   $ button��6�   .\�5+        $ 0:0:6��6   $ 0Q�6+   5,      *� 5-      $' !(UIElement.RenderTransformOrigin)�6"   $ 
textBlock1��6`   .'�5.        $ 0:0:6��6   $ 0.522,0&�6*   5/      T� 50      $ (ToolTipService.ToolTip)�6#   $ cancle��6X   ..�51      i� $ 0:0:6��6   $  ��6-   52      53      54      ��55      �� 56       �� ImageSource$ images/bkg_wood.jpg��6    � Triggers 58      :� 59       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5:      �� #��[  6   �� 5;      #��[ 6   5<      .��5>      � -   5         �Name$
 grid��5>       J� RenderTransformOrigin$ 0.5,0.5&�6   z�5?      V� 5@      .~�5A      �� �� 5B      �� 5C      T� 5D      5E      .+�5G   
   �� -   5         ��Name$ textboxUsername��5G      $
��Left=�6+   $��30��6F   $��
80,120,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��240��6�   $��Oblique$�6�   .��6�    5H        	HelpBrush j� TileMode �� Opacity j� Stretch j� 
AlignmentX  !� Visual��%�   &	       !� 5I      $
 None=�60   $	 0.3Q�6@   $
 None=�6N   $
 Left=�6]     5J      �� 5K      $��Italic$�6$   $��请输入用户名��67   5M      5N      .��6!   ��5O      �� 5P      ! �� 
TargetType"! ��6   " �� Triggers" 5Q      P� 5R      # P� Property# � ��$ P� Value$ 62   Z� . �5S      �� % �� Property% � ��& �� Value#& [ 6;   5T      P� 5U      # � ��$$  ��62   . �5V      �� % � ��#& [ 6;   5W      5Y      .��5Z      5[      �� 5]      -   5        ' ��Name$' 	textBlock��5]      $
��Wrap=�6+   $��南雷皇家技术学院��6?   $��85��6O   $��42.667(�6[   $	��Top=�6m   ( �� TextAlignment$( Center=�6�   $��0,20,0,0q�6�   $��Adobe Fangsong Std R)�6�   �� 5^   
   -   5        $ textboxPassword��5^      $
��Left=�6+   $��30��6F   $��
80,180,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��240��6�   $��Oblique$�6�   .��6�    5_      ��%�   &	       !� 5`      $
 None=�60   $	 0.3Q�6@   $
 None=�6N   $
 Left=�6]     5a      �� 5b      $��Italic$�6$   $��请输入用密码��67   5d      5e      .��6!   ��5f      �� 5g      "! ��6   " 5h      P� 5i      # � ��$ 62   Z� . �5j      �� % � ��#& [ 6;   5k      P� 5l      # � ��$$  ��62   . �5m      �� % � ��#& [ 6;   5n      5p      .��5q      5r      �� 5s   
   -   5        ) ��Name$) cancle��5s      $��取消��6!   $
��Left=�6.   $��150,250,0,0q�6I   $	��Top=�6^   $��75��6v   $ 0.5,0.5&�6�   * � ToolTip$* 退出��6�   z�5t      V� 5u      .~�5v      �� �� 5w      �� 5x      T� 5y      5z      5|      �� 5}      -   5        $) button��5}      $��登陆��6   $
��Left=�6(   $��245,250,0,0q�6C   $	��Top=�6X   $��75��6p   $ 0.5,0.5&�6{   z�5~      V� 5      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�      -   5        $' 
textBlock1��5�      $
��Left=�6"   $��
20,253,0,0q�6=   $
��Wrap=�6Q   $��made by wenyue��6e   $	��Top=�6{   $	��115��6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      5�      5�      