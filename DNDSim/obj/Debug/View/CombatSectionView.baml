   M S B A M L   `   `   `  ����A  =DNDSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DNDSim.ViewDNDSim.View  5      #    DNDSim.View.CombatSectionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:DNDSim.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �5      �� 5      $
��Auto �5      �� 5      $
��Auto �5      �� 5      $
��Auto �5      �� 5      $
��Auto �5      .+�5   
   �� $��Combat��5      $��
1, 1, 1, 1q�5      �� 5   
   $��Attack��5      $��1��5      $��
1, 1, 1, 1q�5      ��5      �� *AttackCommand+5      �� 5   
   $��Full Attack��5      $��2��5       $��
1, 1, 1, 1q�5"      ��5!      �� *FullAttackCommand+5"      �� 5#   
   $��Items��5$      $��3��5%      $��
1, 1, 1, 1q�5'      ��5&      �� *ItemCommand+5'      �� 5(   
   $��End Turn��5)      $��4��5*      $��
1, 1, 1, 1q�5,      ��5+      �� *EndTurnCommand+5,      5-      5.      