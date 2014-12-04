let rec fac n = 
  if n = 0 then 1 else n*fac (n-1);;

let C n k =
  (fac n)/((fac k)*(fac (n-k)));;

C 5 3;;
