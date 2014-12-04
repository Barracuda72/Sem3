let rec makeList p q =
  if List.isEmpty p then q
  elif List.isEmpty q then p
  else
    [List.head p]@[List.head q]@(makeList (List.tail p) (List.tail q));;

makeList ["1";"2";"3";"10"] ["a";"d";"p";"q"];
