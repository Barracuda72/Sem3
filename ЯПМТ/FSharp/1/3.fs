let rec del Q =
  match Q with
  |[] -> []
  |h::t -> h::if t = [] then t else (del (List.tail(t)));;

let inp = [1;2;3;4;5;6;7;8;9];;

del inp;;
