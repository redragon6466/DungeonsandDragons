   M S B A M L   `   `   `  ����A  =DNDSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DNDSimDNDSim  5   	   )clr-namespace:DNDSim.ViewDNDSim.View  5   	   9!clr-namespace:DNDSim.UI.ViewModelDNDSim.UI.ViewModel  5   	       DNDSim.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DNDSim     5   	   (vwclr-namespace:DNDSim.View     5   	   0vm!clr-namespace:DNDSim.UI.ViewModel     5   	     � Title$$  Dungeons and Dragons: The Game��5
   	   $	��350��60   $	��525��6=    � 	Resources 5       �� DataType0   *DNDSim.UI.ViewModel.CombatSectionViewModel#   DNDSim.View.CombatSectionView��%O   (��       5      *, +)�� 5   
   "  5      .R�5        5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �5      $��20��5      �� 5      $
��100* �5      �� 5      $	��100 �5       � ColumnDefinitions 5   
   �� 5      $
��Auto �5      �� 5      $��* �5      .+�5!   	   �� $��1��5#      ��5"      �� *
GetSection+5#      �� 5$   
   -   5        $��OutputWindow��5%      $	��200��5&      " �� VerticalScrollBarVisibility$ Visible=�5'      $��1��5(      $��1��5)      $��2��5*      . �5+      /� .T�5,      J� .*�6   .*�5-      �� �5.      �� *WriteToOutputWindow+5/      50      51      �� 52   
   $��
Characters��53      $��2��54      �� 55   
   $��0,20,0,0q�56      $��2��57      $
��Auto=�5:      ��58      �� *CharactersList+ �� SelectedItem 59      �� *SelectedCharacter+��5;      �� 5<      .R�5=      �� ��5>      �� *Name+5?      5A      5D      5E      