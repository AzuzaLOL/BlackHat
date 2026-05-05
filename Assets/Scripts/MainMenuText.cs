using UnityEngine;
using TMPro;
using System.Collections;

public class MainMenuText : MonoBehaviour
{

    TMP_Text textObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textObj = GetComponent<TMP_Text>();
        textObj.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddText(string text) {
        textObj.text += text;
    }

    public IEnumerator DrawSkull()
    {
        float delay = 0.1f;

        textObj.text += "<color=#ff0000ff>                        @@@@]                            @@@@                                    </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                         XX#@@@       X@@@@@@@b       @@@(@#O                                    </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                         XXXXX@@@@@               @@@@@XX;@#O                                    </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                         XXXXXXOb@@@@           @@@@bOXXr;@#O                                    </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                         ;;<(rXXXXXX@@       @@@@XXXXXXr] @#b                                    </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                       #@@@@r ;]XXXXX@@@@@@@@@OXXXXXX(; (#@#bX                                   </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                       @@@@@@@@'    ;(XXXXXXXXX(;     @@@@@##O                                   </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                         ;@@@@@@@@@@@ ;<]rXr]<; @@@@@@@@@@@@@@#OX                                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                   ']XXXX]; (OOOOr@@@@@b@' '@#@@@@@rOOOO(   ;X@@@@@OOXbbbbbbbb                   </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>@@@@@@@@@@@OXXXXXXXXXXXXXXXX(]]]]<'  @@@@@@@@@@@  '<]]]]rXXXr<'   @@@@@@@@@@@bOOOOOXO            </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>          @@@@@@@@@@#XXXXXXXXXXXXXXX('@@@@@@@@@'(XXXXXXXXXXXXXX(];          @#######bX           </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>               X(((;@@@@@bXXXXXXXXXXX(<;#bbb#;<(XXXXXXXXXX(<'  (bOOOX@@@@@@@@@@@OOOOXO           </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>      O@@@@@            @@@@@@@@OXXXXXXr]<<<]rXXXXXXX(;    @@@@@@@@@@@@@@@O                      </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>       rb  '(OO]               @@@@@@@#OXXXXXXXr(;'   @@@@@@@@@@@@@@](((bb@@ ;                   </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     <(   ;;;;;'<                 @##O@@@XXX(<  X@@@@@@@@@@@@@(rrrOb#@#b@##@@@<r                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     <r< ;';;   @@@@@@@@@@@             @@O] @@@@@@@@@@<'';<<](r((((((X#X@@#@#'r;                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>    <(O] ;''  ;br(rrrrrrrrb@@@@@@@       @@(@@@@@@@ ;;]rOb#@@@@@#bOOOXr(#XX#@X ]r                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>    <(   ''<;@O((;<<;;   ';<<<;((b@@@      @@@@@ '<rbbbbb#;;   <;#bObXXr@OO@@@@]r                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     ]O] ;'' b((X<<    @     '<<;r(]X@@O  '@@X(]rXb#X]<;     @    <;@bXr@OO@@X ];                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     <r; ''' br;;<; @@@@@@@@   <<']<<;;r@@@' ]rXXO#']]' X@@@@@@@@ ((;OOr@OO@@@;r                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     <(;  ;; #r<<;  @@@@@@@@@@  < r;;'b#Or((@bOXXO@<r;;@@@@@@@@@@ ;]<#Or@OO@@@<r                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>      ](# '  Xr<<' @@@@@@@@@@@@ < @#@#OXOObbOXOOXX@<( @@@@@@@@@@@@#<<#Or@OO@ <(;                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>      <]b ''@Xr<<  @@@@@@@@@@@@ ; @rrrXb@ ]@OXXOOX@<( @@@@@@@@@@@@('<#Or@OO@ r(                  </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>      <]O   b](<<' @@@@@@@@@@@@ < @rXb##  O@bOXXOO@<r @@@@@@@@@@@@O;<#Or@OO@ r(#                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     ;]r@ ;'X](<<; ] @@@@@@@@   ' @rb<;'<;((@XOXXO#']; X@@@@@@@@X@r]<bX(#OO@ ;]]                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     <('  OO(](           @      O#b@ <rbb] @XOOXXb#(<<'  @;      ';'Ob@bOO@@@<r                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     ]X<  ]r]]]r@@'         ;  #@bb] (bb    @OXXOXOO#@;]]'  ;;';;;b@#OX#bOO@@b (;                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>    <]<' #br]]<]O##@@@@@      @#b@OX(<    O@@OXXOXXXOb#r(<<<(@@@@#bOX(r#bOO@@@O(r                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>    <]];  Xbr]]< #Xrrrrbr(r(b@OXX''r@    <' @@bOXOOXXOOb#b#bbOOXXr((]##bOXX#@#((r                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     ]r     O]<; #rrrrrXOb#bOXO@#<b'  ' #r]  r#OXXOOXXOOOOOOXXXr]@@@#bOXr@@@@@;(;                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>     ;]r#   b];<@Orrrrrrrrrrrrb <b      r]<] #@bOOXXOXXXXOXrrrrb@bOXrOb@@@@@ ;](                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>       ]r<(<(<@@@bXrrrrrrrrrrr@;<    rOr     r((@bOXOOXOXr(b@@##OXb@@@@@<(< ]r;                  </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>           ]<'   @@@brrrrrrrrr@<]  (b;   @@@   ;;rOOXXOXrr@#bOXrO@@@    ;<                       </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>           <<]]]'   @@@@@#Orrr@<]  <r @@@@@@@@@<]XbOXXX(O@#@@@@@@  '<rrrr(                       </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>               <]]]'      @bXrb ;  (O;   OXrO  ;<rOXXXr@@@@Orb  '<rrrr;                          </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                <<<;;'';;  @@@#@r    ];  Or<'';'@bOXrX@<  ';<;'  '<(r;                           </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                <<]OXXX;<<'   @@@@]XXrr]    @@@#bXXr@@']r((<; @@@@@((                            </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                  <;<;rr;';      @#br   X@@@#XOXXr]@<'](]<XOb@@Or <'                             </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                   <<<((](@@  ';'@bOb@@b@bOXOXOOO@@@O(r(O@O@@b@X'(;                              </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                   <<<r(<<@b@@ <' @@@@@@@@@@@@@@]#@ <((;(O(bb@@@]r                               </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                     <'(<<XbOX                  ;  '<;X#bOO#b@ <'                                </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                     ];r]< @##@@@@@@@@@@@@@@@@@@@@@@@#bOXX@bO@ r                                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                     ]]##O] r@@bXXrrrrrr]#OXXOXXOOXXOOXX((#Xb@ r                                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                     ]r   @O(' O#@@@@#bX]#OXOOXOXXOOXr(Xb#XOb@ r                                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                     ]X     ;@#OXXr<' (X]#OXXXOOXXOXr(@#OO@@@@'r                                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                     ](b; '         X<@@X@@@@@@@#bX(#OXrb@#@# <r                                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                     <](         ' ']'  X<;;;;;<;O@@@@@@@@@@@<rr                                 </color>\n";
        yield return new WaitForSeconds(delay);
        textObj.text += "<color=#ff0000ff>                        rO(rrrrrrXr               ; <<<<<<]';                                    </color>\n";                                                             
    }

    public void StartDrawingSkull()
    {
        StartCoroutine(DrawSkull());
    }
}
