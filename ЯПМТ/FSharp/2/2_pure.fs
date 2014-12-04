let game = [
  [ ["10"; "Ч"]; ["6"; "Б"]; ["В"; "К"] ];
  [ ["11"; "Ч"]; ["7"; "Б"]; ["В"; "B"] ]
];;

let rec comparator2 chFun eqFun p q =
  match q with
    | [] -> false
    | h::t -> (eqFun h (chFun p t)) || (comparator2 chFun eqFun p t);;

let cmpT chFun eqFun =
  comparator2 chFun eqFun;;

let cmpTD x = cmpT (fun a b -> a) x ;;

let hasSimilar p q =
  (cmpT (fun a b -> b) (cmpTD (cmpTD (cmpTD (fun p q -> p = q))))) p q;;

hasSimilar None game;;
