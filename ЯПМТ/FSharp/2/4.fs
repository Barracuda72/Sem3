type tree = None | Node of int*tree*tree;;

let Leaf (x : int) = Node(x,None,None);;

let Test = 
  Node(9,
    Node(7,
      None,
      Node(8,
        Node(9,
          None,
          None
        ),
        Leaf(7)
      )
    ),
    Node(5,
      Leaf(2),
      None
    )
  );;

let max a b = 
  if a > b then a else b;;

let rec treeH t = 
  match t with
  | None -> 0
  | Node(x,l,r) -> (max ((treeH l) + 1) ((treeH r) + 1));;

treeH Test;;
