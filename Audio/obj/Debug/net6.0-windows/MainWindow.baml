   M S B A M L   `   `   `  ����@  <Audio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AudioAudio  5   	       Audio.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Audio     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��51* �6   �� 5      $	��11* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   1  +System.Windows.Controls.Ribbon.RibbonButton  -   5          Name$ 	Randomize��5      $��55��6*   $��55��65   $��	0,10,43,0q�6A   $��1��6T      LargeImageSource$ /5.png��6a   $��Right=�6{   $	��Top=�6�   6�     5   
   -   5        $
 Next��5      $��55��6%   $��55��60   $��
0,10,108,0q�6<   $��1��6P   $ /Audio/3.png��6]   $��Right=�6}   $	��Top=�6�   6�     5   
   -   5        $
 Play��5      $��56��6%   $��55��60   $��
0,10,172,0q�6<   $��1��6P   $ /4.png��6]   $��Right=�6w   $	��Top=�6�   6�     5   
   -   5        $ Previuos��5      $��55��6)   $��55��64   $��
0,10,238,0q�6@   $��1��6T   $ /2.png��6a   $��Right=�6{   $	��Top=�6�   6�     5   
   -   5        $ Repeat��5      $��55��6'   $��55��62   $��
0,10,303,0q�6>   $��1��6R   $ /1.png��6_   $��Right=�6y   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ listbox��5      $��2��6#   $��10,40,10,11q�67   6L   �� 5   
   -   5         ��Name$ slider��5      $��1��6!   $��Center=�61   $��1��6N   $��Center=�6[   $	��380��6v   $��19��6�   6�   �� 5   
   -   5        $!��Открыть музыку��5      $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   $��2��6p   $	��780��6�   $��25��6�   r� 5   
   -	   5         r�Name$ mediaPlayer��5       r� UnloadedBehavior$ Manual=�6,   6F   5      5      