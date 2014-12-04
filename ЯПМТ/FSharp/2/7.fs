let participants =
  ["Первый";"Второй";"Третий";"Четвертый";"Пятый";"Шестой";"Седьмой"];;

let rec counter (n : int) (p : string list) =
  match p with
  | [] -> ""
  | h::t -> match t with
            | [] -> h
            | _ -> if n = 5 then counter 1 t 
                            else (counter (n+1) (t@[h]));;

counter 1 participants
