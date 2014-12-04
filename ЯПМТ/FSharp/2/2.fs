type card = string list;;

type player = card list;;

type players = player list;;

let game = [
  [ ["10"; "Ч"]; ["6"; "Б"]; ["В"; "К"] ];
  [ ["11"; "Ч"]; ["7"; "Б"]; ["В"; "К"] ]
];;

let rec comparator2 chFun eqFun p q =
  match q with
    | [] -> false
    | h::t -> (eqFun h (chFun p t)) || (comparator2 chFun eqFun p t);;

// bool inList(element, list)
(*
let rec inList p q =
  match q with
    | [] -> false
    | h::t -> (h = p) || (inList p t);;
*)

// bool listCmp(list, list)
(*
let rec listCmp p q = 
  match q with
    | [] -> false
    | h::t -> (inList h p) || (listCmp p t);;
*)

// bool isIntersect(list, list of lists)
(*
let rec isIntersect p q = 
  match q with
    | [] -> false
    | h::t -> (listCmp h p) || (isIntersect p t);;
*)

// bool hasSimilar(null, list of lists of lists)
(*
let rec hasSimilar p q =
  match q with
    | [] -> false
    | h::t -> (isIntersect h t) || (hasSimilar p t);;
*)

let cmpF p q = 
  p = q;;

let cmpT chFun eqFun =
  comparator2 chFun eqFun;;

let cmpTD x = cmpT (fun a b -> a) x;;
(*
let inList p q =
  (cmpTD cmpF) p q;;

let listCmp p q =
  (cmpTD inList) p q;;

let isIntersect p q = 
  (cmpTD listCmp) p q;;

let hasSimilar p q =
  (cmpT (fun a b -> b) isIntersect) p q;;
*)

let hasSimilar p q =
  (cmpT (fun a b -> b) (cmpTD (cmpTD (cmpTD cmpF)))) p q;;

hasSimilar None game;;
