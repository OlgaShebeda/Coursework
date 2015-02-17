#Storing elements  
number = operator = prevVal = curVal = keyVal = null
screen         = $('#value')
showOperator   = $('#currentOperator')
newInput       = true
  
$ ->  
  calculate = () ->
    saveCurVal = curVal
switch operator
  when "+" then curVal = parseInt(prevVal, 10) + parseInt(curVal, 10)
  when "−" then curVal = parseInt(prevVal, 10) - parseInt(curVal, 10)
  when "×" then curVal = parseInt(prevVal, 10) * parseInt(curVal, 10)
  when "÷" then curVal = parseInt(prevVal, 10) / parseInt(curVal, 10)
    
prevVal = saveCurVal
screen.val(curVal)
keyVal = null
  
debug = () ->
$('#key').text(keyVal)
$('#current').text(curVal)
$('#previous').text(prevVal)
$('#operator').text(operator)
$('#newInput').text(newInput)
    
          
pushNumber =  $('[data-num]').click ->         
keyVal = $(this).data('num')

if newInput
  if curVal 
    prevVal = screen.val()
  screen.val(keyVal)
  newInput = false
else
  screen.val(screen.val() + keyVal)
curVal = screen.val()      
debug()
      
pushOperator = $('[data-operator]').click ->
if prevVal and !newInput
  calculate() 
newInput = true
    
operator = $(this).data('operator')
showOperator.text(operator)
debug()
      
pushEquals = $('[data-equals]').click ->
calculate()
showOperator.empty()
newInput = true
    
pushClear = $('#clear').click ->
prevVal = curVal = operator = null
newInput = true
showOperator.empty()
screen.val(0)
          
pushNegative = $('#neg').click ->
curVal = 0 - parseInt(curVal, 10)
screen.val(curVal)