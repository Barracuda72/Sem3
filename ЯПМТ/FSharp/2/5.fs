type tree = None | Node of int*tree*tree;;

let Leaf (x : int) = Node(x,None,None);;

let Test = 
  Node(9,
    Node(7,
      None,
      Node(8,
        Node(9,
          None,
          Leaf(3)
        ),
        Leaf(7)
      )
    ),
    Node(5,
      Leaf(2),
      None
    )
  );;

let rec treeC t = 
  match t with
  | None -> 0
  | Node(x,l,r) -> (treeC l) + (treeC r) + 1;;

treeC Test;;
