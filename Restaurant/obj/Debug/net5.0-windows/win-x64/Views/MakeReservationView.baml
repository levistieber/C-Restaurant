   M S B A M L   `   `   `  ????P  LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl  5      E ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Restaurant.ViewsRestaurant.Views 5      *   $Restaurant.Views.MakeReservationView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      UcustomBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Restaurant.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        ? 	Resources  5          BooleanToVisibilityConverter??%   &	        ?? 5   
   6'   5      .??5      ?  ? IsSharedSizeScope$
 True??6    ? RowDefinitions 5   
   ?? 5      $??60 ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5   
   ?? $??0??5       
 Header#??[ 5      $??35(?5       ?? TextAlignment$ Center=?5      $??Make Reservation??5      ? 5    
   $??1??6   $??0 25 0 0q?6    5!      ?? 5"      $
??auto ?6    ?? 5#      $
??auto ?6     ? ColumnDefinitions 5%      ?? 5&      $	??200 ?6#   61   .+?5)      ?? $??0??6   $
??Name??6%   ?? 5*      $??1??5+      $??0 5 0 0q?5,      ??5-      ?? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?5.      ? 50   
   $??2??6   $??0 10 0 0q?6    51      ?? 52      $
??auto ?6    ?? 53      $
??auto ?6     55      ?? 56      $
??auto ?6#   ?? 57      $
??auto ?6#   .+?5:      ?? $??0??5;      $??0??5<      $??	Floor No.??5=      ?? 5>      $??1??5?      $??0??5@      $??0 5 0 0q?5A      ??5B      ?? *FloorNumber+$ PropertyChanged=??? 5D      $??0??5E      $??1??5F      $??10 0 0 0q?5G      $??	Table No.??5H      ?? 5I      $??1??5J      $??1??5K      $??10 5 0 0q?5L      ??5M      ?? *TableNumber+$ PropertyChanged=?5N      ? 5P   
   $??3??6   $??0 10 0 0q?6    5Q      ?? 5R      $
??auto ?6    ?? 5S      $
??auto ?6     5U      ?? 5V      $
??auto ?6#    z? SharedSizeGroup$ FirstColumn??60   ?? 5W      $
??auto ?6#   $ SecondColumn??60   .+?5Z      ?? $??0??5[      $??0??5\      $??Reservation Date??5]      (  "System.Windows.Controls.DatePicker  5^      $??1??5_      $??0??5`      $??0 5 0 0q?5a         SelectedDate 5b      ?? *	ResDate+$ PropertyChanged=?5e      ?? 5g   
   $??4??5h      $??0 25 0 0q?5i       ?? Orientation$ 
Horizontal=?5j      .+?5k      ?? $??Submit??67   ??6   ?? *SubmitCommand+67   ?? 5l      $??10 0 0 0q?5m      $??Cancel??5o      ??5n      ?? *CancelCommand+??5p      ?? 5q      	 ?? BasedOn#	 [B??6   
 ?? 
TargetType"
 ??6G    ?? Triggers 5r      ?? 5s       ?? Binding 6*   ?? *IsSubmitting+ ?? Value True6K   .a?5t   "   ??  ?? Property ? {? ?? Value$ False??6>   5u      5w      5y      *   $LoadingSpinnerControl.LoadingSpinner  5z      $??10 0 0 0q?5{      $??Center=?5|         Diameter$ 25Q?5}         	Thickness$ 3Q?5         Color
 ?   ?   	IsLoading 5~      ?? *IsSubmitting+5?      5?      ?? 5?   
   $??5??5?      $??0 20 0 0q?5?      
???  ????5?      ?? *SubmitErrorMessage+y?5?      ?? *HasSubmitErrorMessage+ ?? 	Converter# [  5?      5?      